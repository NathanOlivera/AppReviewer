using System;
using System.Drawing;
using System.IO;

internal static class ImageUtil
{
    /// <summary>
    /// Converte um array de bytes (vindo do banco) para um objeto Image.
    /// Retorna null se os dados forem inválidos ou nulos.
    /// </summary>
    public static Image ConverterBytesParaImagem(byte[] dados)
    {
        if (dados == null || dados.Length == 0)
            return null;

        try
        {
            using (var ms = new MemoryStream(dados))
            {
                return Image.FromStream(ms);
            }
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// Converte uma imagem para um array de bytes (por exemplo, para armazenar no banco).
    /// </summary>
    public static byte[] ConverterImagemParaBytes(Image imagem)
    {
        if (imagem == null)
            return null;

        using (var ms = new MemoryStream())
        {
            imagem.Save(ms, imagem.RawFormat);
            return ms.ToArray();
        }
    }
}
