using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class LocalData
{
    static public T Load<T>(string file)
    {
        //�t�@�C�����Ȃ�������null�ŕԂ�
        if (!File.Exists(Application.dataPath + "/" + file))
        {
            return default(T);
        }

        var arr = File.ReadAllBytes(Application.dataPath + "/" + file);
#if RELEASE
        arr = AesDecrypt(arr);
#endif

        string json = Encoding.UTF8.GetString(arr);
        return JsonUtility.FromJson<T>(json);
    }

    static public void Save<T>(string file, T data)
    {
        var json = JsonUtility.ToJson(data);
        byte[] arr = Encoding.UTF8.GetBytes(json);
#if RELEASE
        arr = AesEncrypt(arr);
#endif
        File.WriteAllBytes(Application.dataPath + "/" + file, arr);
    }

    /// <summary>
    /// AES�Í���
    /// </summary>
    static public byte[] AesEncrypt(byte[] byteText)
    {
        // AES�ݒ�l
        //===================================
        int aesKeySize = 128;
        int aesBlockSize = 128;
        string aesIv = "6KGhH66PeU3cSLS7";
        string aesKey = "R38FYEzPyjxv0HrE";
        //===================================

        // AES�}�l�[�W���[�擾
        var aes = GetAesManager(aesKeySize, aesBlockSize, aesIv, aesKey);
        // �Í���
        byte[] encryptText = aes.CreateEncryptor().TransformFinalBlock(byteText, 0, byteText.Length);

        return encryptText;
    }

    /// <summary>
    /// AES������
    /// </summary>
    static public byte[] AesDecrypt(byte[] byteText)
    {
        // AES�ݒ�l
        //===================================
        int aesKeySize = 128;
        int aesBlockSize = 128;
        string aesIv = "6KGhH66PeU3cSLS7";
        string aesKey = "R38FYEzPyjxv0HrE";
        //===================================

        // AES�}�l�[�W���[�擾
        var aes = GetAesManager(aesKeySize, aesBlockSize, aesIv, aesKey);
        // ������
        byte[] decryptText = aes.CreateDecryptor().TransformFinalBlock(byteText, 0, byteText.Length);

        return decryptText;
    }

    /// <summary>
    /// AesManaged���擾
    /// </summary>
    /// <param name="keySize">�Í������̒���</param>
    /// <param name="blockSize">�u���b�N�T�C�Y</param>
    /// <param name="iv">�������x�N�g��(���pX�����i8bit * X = [keySize]bit))</param>
    /// <param name="key">�Í����� (��X�����i8bit * X���� = [keySize]bit�j)</param>
    static private AesManaged GetAesManager(int keySize, int blockSize, string iv, string key)
    {
        AesManaged aes = new AesManaged();
        aes.KeySize = keySize;
        aes.BlockSize = blockSize;
        aes.Mode = CipherMode.CBC;
        aes.IV = Encoding.UTF8.GetBytes(iv);
        aes.Key = Encoding.UTF8.GetBytes(key);
        aes.Padding = PaddingMode.PKCS7;
        return aes;
    }


    /// <summary>
    /// XOR
    /// </summary>
    static public byte[] Xor(byte[] a, byte[] b)
    {
        int j = 0;
        for (int i = 0; i < a.Length; i++)
        {
            if (j < b.Length)
            {
                j++;
            }
            else
            {
                j = 1;
            }
            a[i] = (byte)(a[i] ^ b[j - 1]);
        }
        return a;
    }
}