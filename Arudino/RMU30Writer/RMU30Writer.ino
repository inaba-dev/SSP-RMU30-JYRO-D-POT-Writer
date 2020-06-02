#include <Wire.h>

#define DEBUG false

char recvBuf[64];
int recvLen;
char sendBuf[64];
uint8_t tempBuf[64];

#define SERIAL_SOH 0x01
#define SERIAL_EOT 0x04

/* Instruction bits*/
#define AD5172_A0      (1 << 7) // RDAC subaddress select bit.
#define AD5172_SD      (1 << 6) // Shutdown.
#define AD5172_T       (1 << 5) // OTP programming bit.
#define AD5172_DUMMY   (1 << 4) // 
#define AD5172_OW      (1 << 3) // Overwrites the fuse setting and programs the
                                // digital potentiometer to a different setting.

#define ACK false
#define NO_ACK true

#define I2C1 0
#define I2C2 1

int SDA1 = 2;
int SCL1 = 3;
int SDA2 = 4;
int SCL2 = 5;
int OTP_WP = 6;
int OTP_WN = 7;

int CYCLE = 10;

// INPUT、OUTPUT、INPUT_PULLUP

/**********************************************
   初期設定
 *********************************************/

void setup()
{
  ////
  Serial.begin(9600);

  ////
  pinMode(SCL1, OUTPUT);
  pinMode(SDA1, OUTPUT);
  pinMode(SCL2, OUTPUT);
  pinMode(SDA2, OUTPUT);
  pinMode(OTP_WP, OUTPUT);
  pinMode(OTP_WN, OUTPUT);

  ////
  i2c_init();

  ////
  ctrlPowerOn();
}

void i2c_sda_l(int pin)
{
  pinMode(pin, OUTPUT);
  digitalWrite(pin, LOW);
}

void i2c_sda_h(int pin)
{
  pinMode(pin, INPUT);
}

void i2c_scl_l(int pin)
{
  pinMode(pin, OUTPUT);
  digitalWrite(pin, LOW);
}

void i2c_scl_h(int pin)
{
  pinMode(pin, INPUT);
  //pinMode(pin, OUTPUT);
  //digitalWrite(pin, HIGH);
}

/**********************************************
   定常処理
 *********************************************/

void loop()
{
  if(DEBUG)
  {
    Serial.println("=== loop");
    delay(1000);
  }
  else
  {
    delay(100);    
  }
  
  if (execSerialRecv())
  {
    bool bRet;
    ////
    if (!parsePacket()) return;

    ////
    if (recvBuf[1] == 0x12)
      bRet = funcWrite();
    else if (recvBuf[1] == 0x13)
      bRet = funcRead();
    else if (recvBuf[1] == 0x14)
      bRet = funcZapping();

    ////
    if(bRet) execSerialSend();
  }
}

/**********************************************
   ファンクション
 *********************************************/
 
bool funcWrite()
{
  ctrlNormal();

  int addr = (asc2int(recvBuf[2]));
  int data = (asc2int(recvBuf[3]) << 4) | (asc2int(recvBuf[4]));
  int select = ((addr & 0x02) == 0x02)? I2C2 : I2C1;

  uint8_t insbyte = 0x00;
  insbyte  = (addr << 7);
  insbyte |= ((addr & 0x04) == 0x04)? AD5172_OW : 0x00;

  writeAD5172_Register(select, insbyte, data);
  bool bRet = readAD5172_Register(select);
  return bRet;
}

bool funcRead()
{
  ctrlNormal();

  int addr = (asc2int(recvBuf[2]));
  int data = (asc2int(recvBuf[3]) << 4) | (asc2int(recvBuf[4]));
  int select = ((addr & 0x02) == 0x02)? I2C2 : I2C1;

  uint8_t insbyte = 0x00;
  insbyte  = (addr << 7);
  insbyte |= ((addr & 0x04) == 0x04)? AD5172_OW : 0x00;

  nowriteAD5172_Register(select, insbyte, data);
  bool bRet = readAD5172_Register(select);
  return bRet;
}

bool funcShutdown(uint8_t flag)
{
  ctrlNormal();

  int addr = (asc2int(recvBuf[2]));
  int data = (asc2int(recvBuf[3]) << 4) | (asc2int(recvBuf[4]));
  int select = ((addr & 0x02) == 0x02)? I2C2 : I2C1;

  uint8_t insbyte = 0x00;
  insbyte = (addr << 7) | (AD5172_SD * flag);

  nowriteAD5172_Register(select, insbyte, data);
  bool bRet = readAD5172_Register(select);
  return bRet;
}

bool funcZapping()
{
  ctrlZapping();

  int addr = (asc2int(recvBuf[2]));
  int data = (asc2int(recvBuf[3]) << 4) | (asc2int(recvBuf[4]));
  int select = ((addr & 0x02) == 0x02)? I2C2 : I2C1;

  uint8_t insbyte = 0x00;
  insbyte = (addr << 7) | AD5172_T;

  zapwriteAD5172_Register(select, insbyte, data);
  //writeAD5172_Register(select, insbyte, data);
  bool bRet = readAD5172_Register(select);

  ctrlNormal();

  return bRet;
}


/**********************************************
   電源制御
 *********************************************/

void ctrlPowerOn()
{
  digitalWrite(OTP_WP, LOW);
  digitalWrite(OTP_WN, LOW);
}

void ctrlNormal()
{
  digitalWrite(OTP_WP, LOW);
  digitalWrite(OTP_WN, HIGH);
}

void ctrlZapping()
{
  digitalWrite(OTP_WP, LOW);
  digitalWrite(OTP_WN, LOW);
  delay(100);
  digitalWrite(OTP_WP, HIGH);
  digitalWrite(OTP_WN, LOW);
}

/**********************************************
   シリアル通信
 *********************************************/

bool execSerialRecv()
{
  bool hasData = false;
  char recvChar;
  recvLen = 0;

  ////
  if(DEBUG)
  {
    hasData = true;  
    recvBuf[0] = 0x01;
    recvBuf[1] = 0x12;
    recvBuf[2] = 0x30;
    recvBuf[3] = 0x38;
    recvBuf[4] = 0x30;
    recvBuf[5] = 0x35;
    recvBuf[6] = 0x35;
    recvBuf[7] = 0x04;
    recvLen = 8;
  }
  else
  {
    while (Serial.available() > 0)
    {
      hasData = true;
      recvChar = Serial.read();
      recvBuf[recvLen] = recvChar;
      recvLen++;
  
      //// 改行コード(EOT)
      if (recvChar == SERIAL_EOT) {
        break;
      }
  
      //// バッファ以上の場合は中断
      if (recvLen >= 64) {
        break;
      }
    }
  }

  return hasData;
}

void execSerialSend()
{
  int len = createPacket();
    
  for (int i = 0; i < len; i++)
  {
    Serial.write(sendBuf[i]);
  }
}

/******************************************
   送信パケット
 *****************************************/

int createPacket()
{
  int len = 0;

  //// Header
  sendBuf[len++] = SERIAL_SOH;

  //// ファンクションコード
  sendBuf[len++] = recvBuf[1];

  //// アドレス
  sendBuf[len++] = recvBuf[2];

  //// データ
  sendBuf[len++] = int2asc(tempBuf[0] >> 4);
  sendBuf[len++] = int2asc(tempBuf[0] % 16);
  sendBuf[len++] = int2asc(tempBuf[1] >> 4);
  sendBuf[len++] = int2asc(tempBuf[1] % 16);

  //// Checksum
  int sum = 0;
  for (int i = 0; i < len; i++) sum += (int)sendBuf[i];
  int chksum = 256 - (sum % 256);

  sendBuf[len++] = int2asc(chksum >> 4);
  sendBuf[len++] = int2asc(chksum % 16);

  //// Footer
  sendBuf[len++] = SERIAL_EOT;

  return len;
}

bool parsePacket()
{
  if (recvLen < 8) return false;
  
  if (recvBuf[0] != SERIAL_SOH) return false;
  if (recvBuf[7] != SERIAL_EOT) return false;
    
  //// Checksum
  int sum = 0;
  for (int i = 0; i < 5; i++) sum += (int)recvBuf[i];
  int chksum = 256 - (sum % 256);
  int chksum_ref = (asc2int(recvBuf[5]) << 4) | asc2int(recvBuf[6]);

  if(DEBUG) Serial.println(chksum);
  if(DEBUG) Serial.println(chksum_ref);
    
  if (chksum != chksum_ref) return false;

  return true;
}

/******************************************
   AD5172関数
 *****************************************/

#define AD5172_WRITE 0x5E
#define AD5172_READ  0x5F
/*
uint8_t createAD5172_InstructionByte(uint8_t addr, uint8_t otp)
{
  uint8_t insbyte = 0x00;

  insbyte = ((addr & 0x01) == 0x01) ? (insbyte | 0x80) : insbyte;
  insbyte |= otp;
  insbyte |= AD5172_OW;

  return insbyte;
}
*/
void writeAD5172_Register(int select, uint8_t addr, uint8_t data)
{
  i2c_init();
  i2c_start(select);
  i2c_write(select, AD5172_WRITE);
  i2c_write(select, addr);
  i2c_write(select, data);
  i2c_end();
}

void nowriteAD5172_Register(int select, uint8_t addr, uint8_t data)
{
  i2c_init();
  i2c_start(select);
  i2c_write(select, AD5172_WRITE);
  i2c_write(select, addr);
  //i2c_write(select, data);
  i2c_end();
}

void zapwriteAD5172_Register(int select, uint8_t addr, uint8_t data)
{
  i2c_init();
  i2c_start(select);
  i2c_write(select, AD5172_WRITE);
  i2c_write(select, addr);
  i2c_write(select, data);
  i2c_end();
  delay(500);
}

bool readAD5172_Register(int select)
{
  bool bRet = false;
  i2c_init();
  i2c_start(select);
  bRet = i2c_write(select, AD5172_READ);
  tempBuf[0] = i2c_read(select, ACK);
  tempBuf[1] = i2c_read(select, NO_ACK);
  i2c_end();

  //// AD5172から1byteのデータを取得して返却
  return bRet;
}

/******************************************
   I2C関数
 *****************************************/

void i2c_init()
{
  i2c_sda_h(SDA1);
  i2c_sda_h(SDA2);
  i2c_scl_h(SCL1);
  i2c_scl_h(SCL2);
}

void i2c_start(int select)
{
  int SCL = (select == 0) ? SCL1 : SCL2;
  int SDA = (select == 0) ? SDA1 : SDA2;

  i2c_sda_l(SDA);
  delayMicroseconds(CYCLE);
  i2c_scl_l(SCL);
  delayMicroseconds(CYCLE * 2);
}

void i2c_end()
{
  i2c_sda_l(SDA1);
  i2c_sda_l(SDA2);
  delayMicroseconds(CYCLE * 2);
  i2c_scl_h(SCL1);
  i2c_scl_h(SCL2);
  delayMicroseconds(CYCLE);
  i2c_sda_h(SDA1);
  i2c_sda_h(SDA2);
  delay(100);
}

bool i2c_write(int select, uint8_t data)
{
  bool bRet = false;
  int SCL = (select == 0) ? SCL1 : SCL2;
  int SDA = (select == 0) ? SDA1 : SDA2;

  for (int i = 0; i < 8; i++)
  {
    if (((data >> (7 - i)) & 0x01) == 0x01)
      i2c_sda_h(SDA);
    else
      i2c_sda_l(SDA);

    delayMicroseconds(CYCLE);
    i2c_scl_h(SCL);
    delayMicroseconds(CYCLE);
    i2c_scl_l(SCL);
  }

  //// ACK BY SLAVE

  pinMode(SDA, INPUT);

  delayMicroseconds(CYCLE);
  i2c_scl_h(SCL);

  bRet = (digitalRead(SDA)) ? false : true;

  delayMicroseconds(CYCLE);
  i2c_scl_l(SCL);

  return bRet;
}

uint8_t i2c_read(int select, bool bAck)
{
  uint8_t rdata = 0x00;
  int SCL = (select == 0) ? SCL1 : SCL2;
  int SDA = (select == 0) ? SDA1 : SDA2;

  pinMode(SDA, INPUT);

  for (int i = 0; i < 8; i++)
  {
    rdata = (rdata << 1);
    rdata = rdata | digitalRead(SDA);
    //Serial.println(rdata);

    delayMicroseconds(CYCLE);
    i2c_scl_h(SCL);
    delayMicroseconds(CYCLE);
    i2c_scl_l(SCL);
  }

  //// ACK BY MASTER

  if (bAck == true)
    i2c_sda_h(SDA);
  else
    i2c_sda_l(SDA);

  delayMicroseconds(CYCLE);
  i2c_scl_h(SCL);
  delayMicroseconds(CYCLE);
  i2c_scl_l(SCL);  

  return rdata;
}

/******************************************
   共有関数
 *****************************************/

int int2asc(int src)
{
  if (src < 10) return (src + 0x30);
  else if (src < 16) return ((src - 10) + 0x41);
  else return 0;
}

int asc2int(int src)
{
  if (src > 0x40) return (src - 0x41 + 10);
  else if (src >= 0x30) return (src - 0x30);
  else return 0;
}
