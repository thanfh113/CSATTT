﻿using System;
using System.Text;

namespace DESLibrary
{
    public class DES
    {

        private static readonly int[] IP = new int[] {
            58, 50, 42, 34, 26, 18, 10, 2, 60, 52, 44, 36, 28, 20, 12, 4,
            62, 54, 46, 38, 30, 22, 14, 6, 64, 56, 48, 40, 32, 24, 16, 8,
            57, 49, 41, 33, 25, 17, 9, 1, 59, 51, 43, 35, 27, 19, 11, 3,
            61, 53, 45, 37, 29, 21, 13, 5, 63, 55, 47, 39, 31, 23, 15, 7
        };

        private static readonly int[] FP = new int[] {
            40, 8, 48, 16, 56, 24, 64, 32, 39, 7, 47, 15, 55, 23, 63, 31,
            38, 6, 46, 14, 54, 22, 62, 30, 37, 5, 45, 13, 53, 21, 61, 29,
            36, 4, 44, 12, 52, 20, 60, 28, 35, 3, 43, 11, 51, 19, 59, 27,
            34, 2, 42, 10, 50, 18, 58, 26, 33, 1, 41, 9, 49, 17, 57, 25
        };

        private static readonly int[] PC1 = new int[] {
            57, 49, 41, 33, 25, 17, 9, 1, 58, 50, 42, 34, 26, 18,
            10, 2, 59, 51, 43, 35, 27, 19, 11, 3, 60, 52, 44, 36,
            63, 55, 47, 39, 31, 23, 15, 7, 62, 54, 46, 38, 30, 22,
            14, 6, 61, 53, 45, 37, 29, 21, 13, 5, 28, 20, 12, 4
        };

        private static readonly int[] PC2 = new int[] {
            14, 17, 11, 24, 1, 5, 3, 28, 15, 6, 21, 10,
            23, 19, 12, 4, 26, 8, 16, 7, 27, 20, 13, 2,
            41, 52, 31, 37, 47, 55, 30, 40, 51, 45, 33, 48,
            44, 49, 39, 56, 34, 53, 46, 42, 50, 36, 29, 32
        };

        private static readonly int[] E = new int[] {
            32, 1, 2, 3, 4, 5, 4, 5, 6, 7, 8, 9,
            8, 9, 10, 11, 12, 13, 12, 13, 14, 15, 16, 17,
            16, 17, 18, 19, 20, 21, 20, 21, 22, 23, 24, 25,
            24, 25, 26, 27, 28, 29, 28, 29, 30, 31, 32, 1
        };

        private static readonly int[] P = new int[] {
            16, 7, 20, 21, 29, 12, 28, 17, 1, 15, 23, 26,
            5, 18, 31, 10, 2, 8, 24, 14, 32, 27, 3, 9,
            19, 13, 30, 6, 22, 11, 4, 25
        };

        private static readonly int[][,] SBOX = new int[8][,] {
            new int[,] { {14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7},
                         {0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8},
                         {4, 1, 14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0},
                         {15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13} },
            new int[,] { {15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10},
                         {3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5},
                         {0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15},
                         {13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9} },
            new int[,] { {10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8},
                         {13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1},
                         {13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7},
                         {1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12} },
            new int[,] { {7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15},
                         {13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9},
                         {10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4},
                         {3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14} },
            new int[,] { {2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14, 9},
                         {14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3, 9, 8, 6},
                         {4, 2, 1, 11, 10, 13, 7, 8, 15, 9, 12, 5, 6, 3, 0, 14},
                         {11, 8, 12, 7, 1, 14, 2, 13, 6, 15, 0, 9, 10, 4, 5, 3} },
            new int[,] { {12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11},
                         {10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8},
                         {9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6},
                         {4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13} },
            new int[,] { {4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1},
                         {13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6},
                         {1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2},
                         {6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12} },
            new int[,] { {13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7},
                         {1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2},
                         {7, 11, 4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 3, 5, 8},
                         {2, 1, 14, 7, 4, 10, 8, 13, 15, 12, 9, 0, 3, 5, 6, 11} }
        };

        private static readonly int[] SHIFTS = new int[16] { 1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1 };

        private readonly byte[] key;

        public DES(string keyString)
        {
            this.key = Encoding.UTF8.GetBytes(keyString.PadRight(8, '\0').Substring(0, 8));
        }

        public byte[] Encrypt(byte[] data)
        {
            int paddingLength = 8 - (data.Length % 8);
            if (paddingLength == 0) paddingLength = 8;
            byte[] paddedData = new byte[data.Length + paddingLength];
            Array.Copy(data, paddedData, data.Length);
            for (int i = data.Length; i < paddedData.Length; i++)
            {
                paddedData[i] = (byte)paddingLength;
            }

            byte[] result = new byte[paddedData.Length];

            for (int i = 0; i < paddedData.Length; i += 8)
            {
                byte[] block = new byte[8];
                Array.Copy(paddedData, i, block, 0, 8);
                byte[] encryptedBlock = ProcessBlock(block, true);
                Array.Copy(encryptedBlock, 0, result, i, 8);
            }

            return result;
        }

        public byte[] Decrypt(byte[] data)
        {
            if (data.Length % 8 != 0)
            {
                throw new ArgumentException("Encrypted data length must be a multiple of 8 bytes.");
            }

            byte[] result = new byte[data.Length];

            for (int i = 0; i < data.Length; i += 8)
            {
                byte[] block = new byte[8];
                Array.Copy(data, i, block, 0, 8);
                byte[] decryptedBlock = ProcessBlock(block, false);
                Array.Copy(decryptedBlock, 0, result, i, 8);
            }

            int paddingLength = result[result.Length - 1];
            if (paddingLength > 0 && paddingLength <= 8)
            {
                Array.Resize(ref result, result.Length - paddingLength);
            }

            return result;
        }

        private byte[] ProcessBlock(byte[] block, bool encrypt)
        {
            byte[][] keys = GenerateSubKeys();
            byte[] permuted = Permute(block, IP);

            byte[] left = new byte[4];
            byte[] right = new byte[4];
            Array.Copy(permuted, 0, left, 0, 4);
            Array.Copy(permuted, 4, right, 0, 4);

            for (int i = 0; i < 16; i++)
            {
                byte[] temp = new byte[right.Length];
                Array.Copy(right, temp, right.Length);
                right = Xor(left, Feistel(right, keys[encrypt ? i : 15 - i]));
                left = temp;
            }

            byte[] combined = new byte[8];
            Array.Copy(right, 0, combined, 0, 4);
            Array.Copy(left, 0, combined, 4, 4);

            return Permute(combined, FP);
        }

        private byte[][] GenerateSubKeys()
        {
            byte[][] subKeys = new byte[16][];
            for (int i = 0; i < 16; i++)
            {
                subKeys[i] = new byte[6];
            }

            byte[] permutedKey = Permute(key, PC1);
            byte[] C = new byte[4];
            byte[] D = new byte[4];
            for (int i = 0; i < 28; i++)
            {
                SetBit(C, i, GetBit(permutedKey, i));
                SetBit(D, i, GetBit(permutedKey, i + 28));
            }

            for (int i = 0; i < 16; i++)
            {
                LeftShift(C, SHIFTS[i], 28);
                LeftShift(D, SHIFTS[i], 28);
                byte[] combined = new byte[7];
                for (int j = 0; j < 28; j++)
                {
                    SetBit(combined, j, GetBit(C, j));
                    SetBit(combined, j + 28, GetBit(D, j));
                }
                subKeys[i] = Permute(combined, PC2);
            }

            return subKeys;
        }

        private byte[] Permute(byte[] input, int[] table)
        {
            byte[] result = new byte[table.Length / 8];
            for (int i = 0; i < table.Length; i++)
            {
                int pos = table[i] - 1;
                int bytePos = pos / 8;
                int bitPos = 7 - (pos % 8);
                int resultBytePos = i / 8;
                int resultBitPos = 7 - (i % 8);

                if ((input[bytePos] & (1 << bitPos)) != 0)
                    result[resultBytePos] |= (byte)(1 << resultBitPos);
            }
            return result;
        }

        private static void SetBit(byte[] data, int pos, int value)
        {
            int bytePos = pos / 8;
            int bitPos = 7 - (pos % 8);
            if (value != 0)
                data[bytePos] |= (byte)(1 << bitPos);
            else
                data[bytePos] &= (byte)~(1 << bitPos);
        }

        private static int GetBit(byte[] data, int pos)
        {
            int bytePos = pos / 8;
            int bitPos = 7 - (pos % 8);
            return (data[bytePos] >> bitPos) & 1;
        }

        private static void LeftShift(byte[] data, int bits, int len)
        {
            byte[] temp = new byte[4];
            for (int i = 0; i < len; i++)
            {
                SetBit(temp, i, GetBit(data, (i + bits) % len));
            }
            Array.Copy(temp, data, 4);
        }

        private byte[] Feistel(byte[] right, byte[] subKey)
        {
            byte[] expanded = Permute(right, E);
            byte[] xored = Xor(expanded, subKey);
            byte[] substituted = new byte[4];

            for (int i = 0; i < 8; i++)
            {
                int start = i * 6;
                int row = (GetBit(xored, start) << 1) | GetBit(xored, start + 5);
                int col = (GetBit(xored, start + 1) << 3) | (GetBit(xored, start + 2) << 2) |
                          (GetBit(xored, start + 3) << 1) | GetBit(xored, start + 4);
                int val = SBOX[i][row, col];
                for (int j = 0; j < 4; j++)
                {
                    SetBit(substituted, i * 4 + j, (val >> (3 - j)) & 1);
                }
            }

            return Permute(substituted, P);
        }

        private byte[] Xor(byte[] a, byte[] b)
        {
            byte[] result = new byte[Math.Min(a.Length, b.Length)];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (byte)(a[i] ^ b[i]);
            }
            return result;
        }
    }
}