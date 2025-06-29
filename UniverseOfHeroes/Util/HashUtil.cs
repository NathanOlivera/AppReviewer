﻿using System.Security.Cryptography;
using System.Text;

public static class HashUtil
{
    public static string GerarHashSha256(string texto)
    {
        using (SHA256 sha = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(texto);
            byte[] hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
