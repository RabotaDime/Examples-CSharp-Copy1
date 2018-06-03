﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace My.Utils
{
    public class CBitwiseOps
    {
        public static int BitsCount (Enum value)
        {
            //   Не идеальный способ конверсии с использованием, 
            //   конверсии в object, но в C# надо долго искать 
            //   альтернативы, а небезопасный код и Reflection
            //   напрямую я использовать не хочу. 
            return BitsCount(Convert.ToUInt64(value));
        }

        public static int BitsCount (uint value)
        {
            return
            (
                BitsCountLookupTable1 [(byte) ( value & 0xFF )] +
                BitsCountLookupTable1 [(byte) ( value >>  8  )] +
                BitsCountLookupTable1 [(byte) ( value >> 16  )] +
                BitsCountLookupTable1 [(byte) ( value >> 24  )]
            );    
        }

        public static int BitsCount (ulong value)
        {
            return
            (
                BitsCountLookupTable1 [(byte) ( value & 0xFF )] +
                BitsCountLookupTable1 [(byte) ( value >>  8  )] +
                BitsCountLookupTable1 [(byte) ( value >> 16  )] +
                BitsCountLookupTable1 [(byte) ( value >> 24  )] +

                BitsCountLookupTable1 [(byte) ( value >> 32  )] +
                BitsCountLookupTable1 [(byte) ( value >> 40  )] +
                BitsCountLookupTable1 [(byte) ( value >> 48  )] +
                BitsCountLookupTable1 [(byte) ( value >> 56  )]
            );    
        }



        //   Можно было бы использовать fixed, но я не хочу делать проект 
        //   с "unsafe" кодом. 
        #region Массив-таблица для быстрого поиска ответа (1 байт -> Сколько битов включено?)
        //   BM = Bit Mask, маска для вариантов размером в половину байта
        private const byte BC_0000 = 0;
        private const byte BC_0001 = 1;
        private const byte BC_0010 = 1;
        private const byte BC_0011 = 2;
        private const byte BC_0100 = 1;
        private const byte BC_0101 = 2;
        private const byte BC_0110 = 2;
        private const byte BC_0111 = 3;
        private const byte BC_1000 = 1;
        private const byte BC_1001 = 2;
        private const byte BC_1010 = 2;
        private const byte BC_1011 = 3;
        private const byte BC_1100 = 2;
        private const byte BC_1101 = 3;
        private const byte BC_1110 = 3;
        private const byte BC_1111 = 4;

        private static readonly byte[] BitsCountLookupTable1 = new byte[256]
        {
            #region Старшая серия битов = [BM_0000]
            /*  (  0)  0000 0000  */ BC_0000 + BC_0000,
            /*  (  1)  0000 0001  */ BC_0000 + BC_0001,
            /*  (  2)  0000 0010  */ BC_0000 + BC_0010,
            /*  (  3)  0000 0011  */ BC_0000 + BC_0011,
            /*  (  4)  0000 0100  */ BC_0000 + BC_0100,
            /*  (  5)  0000 0101  */ BC_0000 + BC_0101,
            /*  (  6)  0000 0110  */ BC_0000 + BC_0110,
            /*  (  7)  0000 0111  */ BC_0000 + BC_0111,
            /*  (  8)  0000 1000  */ BC_0000 + BC_1000,
            /*  (  9)  0000 1001  */ BC_0000 + BC_1001,
            /*  ( 10)  0000 1010  */ BC_0000 + BC_1010,
            /*  ( 11)  0000 1011  */ BC_0000 + BC_1011,
            /*  ( 12)  0000 1100  */ BC_0000 + BC_1100,
            /*  ( 13)  0000 1101  */ BC_0000 + BC_1101,
            /*  ( 14)  0000 1110  */ BC_0000 + BC_1110,
            /*  ( 15)  0000 1111  */ BC_0000 + BC_1111,
            #endregion
            #region Старшая серия битов = [BM_0001]
            /*  ( 16)  0001 0000  */ BC_0001 + BC_0000,
            /*  ( 17)  0001 0001  */ BC_0001 + BC_0001,
            /*  ( 18)  0001 0010  */ BC_0001 + BC_0010,
            /*  ( 19)  0001 0011  */ BC_0001 + BC_0011,
            /*  ( 20)  0001 0100  */ BC_0001 + BC_0100,
            /*  ( 21)  0001 0101  */ BC_0001 + BC_0101,
            /*  ( 22)  0001 0110  */ BC_0001 + BC_0110,
            /*  ( 23)  0001 0111  */ BC_0001 + BC_0111,
            /*  ( 24)  0001 1000  */ BC_0001 + BC_1000,
            /*  ( 25)  0001 1001  */ BC_0001 + BC_1001,
            /*  ( 26)  0001 1010  */ BC_0001 + BC_1010,
            /*  ( 27)  0001 1011  */ BC_0001 + BC_1011,
            /*  ( 28)  0001 1100  */ BC_0001 + BC_1100,
            /*  ( 29)  0001 1101  */ BC_0001 + BC_1101,
            /*  ( 30)  0001 1110  */ BC_0001 + BC_1110,
            /*  ( 31)  0001 1111  */ BC_0001 + BC_1111,
            #endregion
            #region Старшая серия битов = [BM_0010]
            /*  ( 32)  0010 0000  */ BC_0010 + BC_0000,
            /*  ( 33)  0010 0001  */ BC_0010 + BC_0001,
            /*  ( 34)  0010 0010  */ BC_0010 + BC_0010,
            /*  ( 35)  0010 0011  */ BC_0010 + BC_0011,
            /*  ( 36)  0010 0100  */ BC_0010 + BC_0100,
            /*  ( 37)  0010 0101  */ BC_0010 + BC_0101,
            /*  ( 38)  0010 0110  */ BC_0010 + BC_0110,
            /*  ( 39)  0010 0111  */ BC_0010 + BC_0111,
            /*  ( 40)  0010 1000  */ BC_0010 + BC_1000,
            /*  ( 41)  0010 1001  */ BC_0010 + BC_1001,
            /*  ( 42)  0010 1010  */ BC_0010 + BC_1010,
            /*  ( 43)  0010 1011  */ BC_0010 + BC_1011,
            /*  ( 44)  0010 1100  */ BC_0010 + BC_1100,
            /*  ( 45)  0010 1101  */ BC_0010 + BC_1101,
            /*  ( 46)  0010 1110  */ BC_0010 + BC_1110,
            /*  ( 47)  0010 1111  */ BC_0010 + BC_1111,
            #endregion
            #region Старшая серия битов = [BM_0011]
            /*  ( 48)  0011 0000  */ BC_0011 + BC_0000,
            /*  ( 49)  0011 0001  */ BC_0011 + BC_0001,
            /*  ( 50)  0011 0010  */ BC_0011 + BC_0010,
            /*  ( 51)  0011 0011  */ BC_0011 + BC_0011,
            /*  ( 52)  0011 0100  */ BC_0011 + BC_0100,
            /*  ( 53)  0011 0101  */ BC_0011 + BC_0101,
            /*  ( 54)  0011 0110  */ BC_0011 + BC_0110,
            /*  ( 55)  0011 0111  */ BC_0011 + BC_0111,
            /*  ( 56)  0011 1000  */ BC_0011 + BC_1000,
            /*  ( 57)  0011 1001  */ BC_0011 + BC_1001,
            /*  ( 58)  0011 1010  */ BC_0011 + BC_1010,
            /*  ( 59)  0011 1011  */ BC_0011 + BC_1011,
            /*  ( 60)  0011 1100  */ BC_0011 + BC_1100,
            /*  ( 61)  0011 1101  */ BC_0011 + BC_1101,
            /*  ( 62)  0011 1110  */ BC_0011 + BC_1110,
            /*  ( 63)  0011 1111  */ BC_0011 + BC_1111,
            #endregion
            #region Старшая серия битов = [BM_0100]
            /*  ( 64)  0100 0000  */ BC_0100 + BC_0000,
            /*  ( 65)  0100 0001  */ BC_0100 + BC_0001,
            /*  ( 66)  0100 0010  */ BC_0100 + BC_0010,
            /*  ( 67)  0100 0011  */ BC_0100 + BC_0011,
            /*  ( 68)  0100 0100  */ BC_0100 + BC_0100,
            /*  ( 69)  0100 0101  */ BC_0100 + BC_0101,
            /*  ( 70)  0100 0110  */ BC_0100 + BC_0110,
            /*  ( 71)  0100 0111  */ BC_0100 + BC_0111,
            /*  ( 72)  0100 1000  */ BC_0100 + BC_1000,
            /*  ( 73)  0100 1001  */ BC_0100 + BC_1001,
            /*  ( 74)  0100 1010  */ BC_0100 + BC_1010,
            /*  ( 75)  0100 1011  */ BC_0100 + BC_1011,
            /*  ( 76)  0100 1100  */ BC_0100 + BC_1100,
            /*  ( 77)  0100 1101  */ BC_0100 + BC_1101,
            /*  ( 78)  0100 1110  */ BC_0100 + BC_1110,
            /*  ( 79)  0100 1111  */ BC_0100 + BC_1111,
            #endregion
            #region Старшая серия битов = [BM_0101]
            /*  ( 80)  0101 0000  */ BC_0101 + BC_0000,
            /*  ( 81)  0101 0001  */ BC_0101 + BC_0001,
            /*  ( 82)  0101 0010  */ BC_0101 + BC_0010,
            /*  ( 83)  0101 0011  */ BC_0101 + BC_0011,
            /*  ( 84)  0101 0100  */ BC_0101 + BC_0100,
            /*  ( 85)  0101 0101  */ BC_0101 + BC_0101,
            /*  ( 86)  0101 0110  */ BC_0101 + BC_0110,
            /*  ( 87)  0101 0111  */ BC_0101 + BC_0111,
            /*  ( 88)  0101 1000  */ BC_0101 + BC_1000,
            /*  ( 89)  0101 1001  */ BC_0101 + BC_1001,
            /*  ( 90)  0101 1010  */ BC_0101 + BC_1010,
            /*  ( 91)  0101 1011  */ BC_0101 + BC_1011,
            /*  ( 92)  0101 1100  */ BC_0101 + BC_1100,
            /*  ( 93)  0101 1101  */ BC_0101 + BC_1101,
            /*  ( 94)  0101 1110  */ BC_0101 + BC_1110,
            /*  ( 95)  0101 1111  */ BC_0101 + BC_1111,
            #endregion
            #region Старшая серия битов = [BM_0110]
            /*  ( 96)  0110 0000  */ BC_0110 + BC_0000,
            /*  ( 97)  0110 0001  */ BC_0110 + BC_0001,
            /*  ( 98)  0110 0010  */ BC_0110 + BC_0010,
            /*  ( 99)  0110 0011  */ BC_0110 + BC_0011,
            /*  (100)  0110 0100  */ BC_0110 + BC_0100,
            /*  (101)  0110 0101  */ BC_0110 + BC_0101,
            /*  (102)  0110 0110  */ BC_0110 + BC_0110,
            /*  (103)  0110 0111  */ BC_0110 + BC_0111,
            /*  (104)  0110 1000  */ BC_0110 + BC_1000,
            /*  (105)  0110 1001  */ BC_0110 + BC_1001,
            /*  (106)  0110 1010  */ BC_0110 + BC_1010,
            /*  (107)  0110 1011  */ BC_0110 + BC_1011,
            /*  (108)  0110 1100  */ BC_0110 + BC_1100,
            /*  (109)  0110 1101  */ BC_0110 + BC_1101,
            /*  (110)  0110 1110  */ BC_0110 + BC_1110,
            /*  (111)  0110 1111  */ BC_0110 + BC_1111,
            #endregion
            #region Старшая серия битов = [BM_0111]
            /*  (112)  0111 0000  */ BC_0111 + BC_0000,
            /*  (113)  0111 0001  */ BC_0111 + BC_0001,
            /*  (114)  0111 0010  */ BC_0111 + BC_0010,
            /*  (115)  0111 0011  */ BC_0111 + BC_0011,
            /*  (116)  0111 0100  */ BC_0111 + BC_0100,
            /*  (117)  0111 0101  */ BC_0111 + BC_0101,
            /*  (118)  0111 0110  */ BC_0111 + BC_0110,
            /*  (119)  0111 0111  */ BC_0111 + BC_0111,
            /*  (120)  0111 1000  */ BC_0111 + BC_1000,
            /*  (121)  0111 1001  */ BC_0111 + BC_1001,
            /*  (122)  0111 1010  */ BC_0111 + BC_1010,
            /*  (123)  0111 1011  */ BC_0111 + BC_1011,
            /*  (124)  0111 1100  */ BC_0111 + BC_1100,
            /*  (125)  0111 1101  */ BC_0111 + BC_1101,
            /*  (126)  0111 1110  */ BC_0111 + BC_1110,
            /*  (127)  0111 1111  */ BC_0111 + BC_1111,
            #endregion
            #region Старшая серия битов = [BM_1000]
            /*  (128)  1000 0000  */ BC_1000 + BC_0000,
            /*  (129)  1000 0001  */ BC_1000 + BC_0001,
            /*  (130)  1000 0010  */ BC_1000 + BC_0010,
            /*  (131)  1000 0011  */ BC_1000 + BC_0011,
            /*  (132)  1000 0100  */ BC_1000 + BC_0100,
            /*  (133)  1000 0101  */ BC_1000 + BC_0101,
            /*  (134)  1000 0110  */ BC_1000 + BC_0110,
            /*  (135)  1000 0111  */ BC_1000 + BC_0111,
            /*  (136)  1000 1000  */ BC_1000 + BC_1000,
            /*  (137)  1000 1001  */ BC_1000 + BC_1001,
            /*  (138)  1000 1010  */ BC_1000 + BC_1010,
            /*  (139)  1000 1011  */ BC_1000 + BC_1011,
            /*  (140)  1000 1100  */ BC_1000 + BC_1100,
            /*  (141)  1000 1101  */ BC_1000 + BC_1101,
            /*  (142)  1000 1110  */ BC_1000 + BC_1110,
            /*  (143)  1000 1111  */ BC_1000 + BC_1111,
            #endregion
            #region Старшая серия битов = [BM_1001]
            /*  (144)  1001 0000  */ BC_1001 + BC_0000,
            /*  (145)  1001 0001  */ BC_1001 + BC_0001,
            /*  (146)  1001 0010  */ BC_1001 + BC_0010,
            /*  (147)  1001 0011  */ BC_1001 + BC_0011,
            /*  (148)  1001 0100  */ BC_1001 + BC_0100,
            /*  (149)  1001 0101  */ BC_1001 + BC_0101,
            /*  (150)  1001 0110  */ BC_1001 + BC_0110,
            /*  (151)  1001 0111  */ BC_1001 + BC_0111,
            /*  (152)  1001 1000  */ BC_1001 + BC_1000,
            /*  (153)  1001 1001  */ BC_1001 + BC_1001,
            /*  (154)  1001 1010  */ BC_1001 + BC_1010,
            /*  (155)  1001 1011  */ BC_1001 + BC_1011,
            /*  (156)  1001 1100  */ BC_1001 + BC_1100,
            /*  (157)  1001 1101  */ BC_1001 + BC_1101,
            /*  (158)  1001 1110  */ BC_1001 + BC_1110,
            /*  (159)  1001 1111  */ BC_1001 + BC_1111,
            #endregion
            #region Старшая серия битов = [BM_1010]
            /*  (160)  1010 0000  */ BC_1010 + BC_0000,
            /*  (161)  1010 0001  */ BC_1010 + BC_0001,
            /*  (162)  1010 0010  */ BC_1010 + BC_0010,
            /*  (163)  1010 0011  */ BC_1010 + BC_0011,
            /*  (164)  1010 0100  */ BC_1010 + BC_0100,
            /*  (165)  1010 0101  */ BC_1010 + BC_0101,
            /*  (166)  1010 0110  */ BC_1010 + BC_0110,
            /*  (167)  1010 0111  */ BC_1010 + BC_0111,
            /*  (168)  1010 1000  */ BC_1010 + BC_1000,
            /*  (169)  1010 1001  */ BC_1010 + BC_1001,
            /*  (170)  1010 1010  */ BC_1010 + BC_1010,
            /*  (171)  1010 1011  */ BC_1010 + BC_1011,
            /*  (172)  1010 1100  */ BC_1010 + BC_1100,
            /*  (173)  1010 1101  */ BC_1010 + BC_1101,
            /*  (174)  1010 1110  */ BC_1010 + BC_1110,
            /*  (175)  1010 1111  */ BC_1010 + BC_1111,
            #endregion
            #region Старшая серия битов = [BM_1011]
            /*  (176)  1011 0000  */ BC_1011 + BC_0000,
            /*  (177)  1011 0001  */ BC_1011 + BC_0001,
            /*  (178)  1011 0010  */ BC_1011 + BC_0010,
            /*  (179)  1011 0011  */ BC_1011 + BC_0011,
            /*  (180)  1011 0100  */ BC_1011 + BC_0100,
            /*  (181)  1011 0101  */ BC_1011 + BC_0101,
            /*  (182)  1011 0110  */ BC_1011 + BC_0110,
            /*  (183)  1011 0111  */ BC_1011 + BC_0111,
            /*  (184)  1011 1000  */ BC_1011 + BC_1000,
            /*  (185)  1011 1001  */ BC_1011 + BC_1001,
            /*  (186)  1011 1010  */ BC_1011 + BC_1010,
            /*  (187)  1011 1011  */ BC_1011 + BC_1011,
            /*  (188)  1011 1100  */ BC_1011 + BC_1100,
            /*  (189)  1011 1101  */ BC_1011 + BC_1101,
            /*  (190)  1011 1110  */ BC_1011 + BC_1110,
            /*  (191)  1011 1111  */ BC_1011 + BC_1111,
            #endregion
            #region Старшая серия битов = [BM_1100]
            /*  (192)  1100 0000  */ BC_1100 + BC_0000,
            /*  (193)  1100 0001  */ BC_1100 + BC_0001,
            /*  (194)  1100 0010  */ BC_1100 + BC_0010,
            /*  (195)  1100 0011  */ BC_1100 + BC_0011,
            /*  (196)  1100 0100  */ BC_1100 + BC_0100,
            /*  (197)  1100 0101  */ BC_1100 + BC_0101,
            /*  (198)  1100 0110  */ BC_1100 + BC_0110,
            /*  (199)  1100 0111  */ BC_1100 + BC_0111,
            /*  (200)  1100 1000  */ BC_1100 + BC_1000,
            /*  (201)  1100 1001  */ BC_1100 + BC_1001,
            /*  (202)  1100 1010  */ BC_1100 + BC_1010,
            /*  (203)  1100 1011  */ BC_1100 + BC_1011,
            /*  (204)  1100 1100  */ BC_1100 + BC_1100,
            /*  (205)  1100 1101  */ BC_1100 + BC_1101,
            /*  (206)  1100 1110  */ BC_1100 + BC_1110,
            /*  (207)  1100 1111  */ BC_1100 + BC_1111,
            #endregion
            #region Старшая серия битов = [BM_1101]
            /*  (208)  1101 0000  */ BC_1101 + BC_0000,
            /*  (209)  1101 0001  */ BC_1101 + BC_0001,
            /*  (210)  1101 0010  */ BC_1101 + BC_0010,
            /*  (211)  1101 0011  */ BC_1101 + BC_0011,
            /*  (212)  1101 0100  */ BC_1101 + BC_0100,
            /*  (213)  1101 0101  */ BC_1101 + BC_0101,
            /*  (214)  1101 0110  */ BC_1101 + BC_0110,
            /*  (215)  1101 0111  */ BC_1101 + BC_0111,
            /*  (216)  1101 1000  */ BC_1101 + BC_1000,
            /*  (217)  1101 1001  */ BC_1101 + BC_1001,
            /*  (218)  1101 1010  */ BC_1101 + BC_1010,
            /*  (219)  1101 1011  */ BC_1101 + BC_1011,
            /*  (220)  1101 1100  */ BC_1101 + BC_1100,
            /*  (221)  1101 1101  */ BC_1101 + BC_1101,
            /*  (222)  1101 1110  */ BC_1101 + BC_1110,
            /*  (223)  1101 1111  */ BC_1101 + BC_1111,
            #endregion
            #region Старшая серия битов = [BM_1110]
            /*  (224)  1110 0000  */ BC_1110 + BC_0000,
            /*  (225)  1110 0001  */ BC_1110 + BC_0001,
            /*  (226)  1110 0010  */ BC_1110 + BC_0010,
            /*  (227)  1110 0011  */ BC_1110 + BC_0011,
            /*  (228)  1110 0100  */ BC_1110 + BC_0100,
            /*  (229)  1110 0101  */ BC_1110 + BC_0101,
            /*  (230)  1110 0110  */ BC_1110 + BC_0110,
            /*  (231)  1110 0111  */ BC_1110 + BC_0111,
            /*  (232)  1110 1000  */ BC_1110 + BC_1000,
            /*  (233)  1110 1001  */ BC_1110 + BC_1001,
            /*  (234)  1110 1010  */ BC_1110 + BC_1010,
            /*  (235)  1110 1011  */ BC_1110 + BC_1011,
            /*  (236)  1110 1100  */ BC_1110 + BC_1100,
            /*  (237)  1110 1101  */ BC_1110 + BC_1101,
            /*  (238)  1110 1110  */ BC_1110 + BC_1110,
            /*  (239)  1110 1111  */ BC_1110 + BC_1111,
            #endregion
            #region Старшая серия битов = [BM_1111]
            /*  (240)  1111 0000  */ BC_1111 + BC_0000,
            /*  (241)  1111 0001  */ BC_1111 + BC_0001,
            /*  (242)  1111 0010  */ BC_1111 + BC_0010,
            /*  (243)  1111 0011  */ BC_1111 + BC_0011,
            /*  (244)  1111 0100  */ BC_1111 + BC_0100,
            /*  (245)  1111 0101  */ BC_1111 + BC_0101,
            /*  (246)  1111 0110  */ BC_1111 + BC_0110,
            /*  (247)  1111 0111  */ BC_1111 + BC_0111,
            /*  (248)  1111 1000  */ BC_1111 + BC_1000,
            /*  (249)  1111 1001  */ BC_1111 + BC_1001,
            /*  (250)  1111 1010  */ BC_1111 + BC_1010,
            /*  (251)  1111 1011  */ BC_1111 + BC_1011,
            /*  (252)  1111 1100  */ BC_1111 + BC_1100,
            /*  (253)  1111 1101  */ BC_1111 + BC_1101,
            /*  (254)  1111 1110  */ BC_1111 + BC_1110,
            /*  (255)  1111 1111  */ BC_1111 + BC_1111,
            #endregion
        };
        #endregion
    }
}