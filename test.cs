/*
 * How to compile:
 * mcs test.cs
 *
 * How to run:
 * mono test.exe 'arg[0] - encrypted message'
 */
using System;
using System.Security.Cryptography;

public class Test {

  public static string encrypt(string text, string publicKey) {
    using (var rsa = new RSACryptoServiceProvider()) {
      rsa.FromXmlString(publicKey);
      var bytesPlainTextData = System.Text.Encoding.Unicode.GetBytes(text);
      var bytesCypherText = rsa.Encrypt(bytesPlainTextData, false);

      return Convert.ToBase64String(bytesCypherText);
    }
  }
  
  public static string decrypt(string text, string privateKey) {
    byte[] cypherText = Convert.FromBase64String(text);
    using (var rsa = new RSACryptoServiceProvider()) {
      rsa.FromXmlString(privateKey);
      var bytesText = rsa.Decrypt(cypherText, false);
      return System.Text.Encoding.UTF8.GetString(bytesText);
    }
  }

  public static void Main(string[] args) {
    //Console.WriteLine("Hello World!");
    string example_public_key_xml = "<RSAKeyValue><Modulus>sW3Va/RS78FUr3Ov9acUe1v8wQGJD+fJVySeM8ecefppYBpCIMxJxzecvQbBkjhYUgjisTU+srCszO2j8Bfp2m18yEET1LGKVmn/v5g0o/kpgOx4Q3u6S2TEwOUcjbAEMWOGtDXhnLHDkjU7R9EahEEhdoFNW3FJ99sV3EpgvDkYA8Mf9O8h9DPgtquWEb0yrQwyF2jgFT26S4GrPA8u5jh41EyhVnZLTT3Yvpu6a0VivsQPYMebs+hnAuJz4RSvwO0l5sEzG9U2FURazJX2v2Dzv9dbFr6GX+QRF3ZpO0434CHBYamZokaA4tlmrumgvuSrWMy+lmkYi5HGY6anhw==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
    string encrypted_message = encrypt("Hello World!", example_public_key_xml);
    //Console.WriteLine(encrypted_message);
    string example_private_key_xml = "<RSAKeyValue><Modulus>sW3Va/RS78FUr3Ov9acUe1v8wQGJD+fJVySeM8ecefppYBpCIMxJxzecvQbBkjhYUgjisTU+srCszO2j8Bfp2m18yEET1LGKVmn/v5g0o/kpgOx4Q3u6S2TEwOUcjbAEMWOGtDXhnLHDkjU7R9EahEEhdoFNW3FJ99sV3EpgvDkYA8Mf9O8h9DPgtquWEb0yrQwyF2jgFT26S4GrPA8u5jh41EyhVnZLTT3Yvpu6a0VivsQPYMebs+hnAuJz4RSvwO0l5sEzG9U2FURazJX2v2Dzv9dbFr6GX+QRF3ZpO0434CHBYamZokaA4tlmrumgvuSrWMy+lmkYi5HGY6anhw==</Modulus><Exponent>AQAB</Exponent><P>2/uE9MaV5VzrxM9wgHmCS/J/9N3Rbk5xJz4M+URtC/epztGup6dKdWlfkHDl2gZ3lrrPjPGfwW7JMUG50oatp8a9A0gVTToyXdn6ogcArG2KlzPEqPaW9V2iQ+h9Dbot5U9JhH7725YYkyAGxELbIi+LppZnA+QiM3FyARG8U2s=</P><Q>znqz4FFDCkVekoSt7X3+b+Sx27n7eQbvHBJpsgTvGABlRrncOUDS6mI3FB4dOiQzMQFt5jR94URYaBjGOCQ5WNCr16ZMEdOo5O37o73faTTJyGtOgl2CASOjgGW9SSMmS3PrXtCr7ZRdc16Ek4j/7DrR5uNHPiqt8XWmaNxPH1U=</Q><DP>b4ADGhZ177WzgyQpv9TW6CvYE4NDHggAboWTCd1W8FPt6/h38F5o7S4l1A6FUocoomu5u5TVBrRioebQixbcekfPkhQ9R9GRqeRMl0e5XayALLd+nK2wQlndX1I94HFXxfz0JIZAnkJr3lbDV0MT0zYKMLvXJy/A7hY4VLZqoFU=</DP><DQ>bUy+00uw9UrrWRwrBcDgY1LoY6v71oE5Kd8FXFsIRehPtDTGwvfxrmj3Rwr55cEr6BEdn/LBf/Gx6sjShP2H7d/oV2uMcRNeIHFp96+XCBYNiq5jDNd67idzcZBptsGIkAB44+QKXuVe4qdx/rdS4jXwzwwYtmvZUCw7Pt8Ac1E=</DQ><InverseQ>M8PqKkI6ZHV9MUAtzvg/gFJaNI9QUXBUlE5r/JuVLThipo/2uzsYShDKjY8ad31NW6mDAuXFzP/XsQmvBbN8Nn3l35uc+9MfaAc1wriDav+upafIwa6fwjapPQ2PN0sM64bO/shovwebJ9USBdYrRZjf0Q3PzU+p1HQc+Nbz55I=</InverseQ><D>Cihnl46dUOyYlJLi+AVgvs89YS9dUXPLqxmFlSFQbAtSDRZzwrzvXGBqsMe6PUzMgaXQlKSfukszGWhhglVcJg0un6haIksnyFq5MZbdLKYPIjpniDWFLNvQB9sWD2aMVueDxr1u9TGYKL6zbiEii3/PEqHEc//AZFg+oCYB88SYmQnZz1598wKTwvih2x6rDwM5obykORfMwAKZNKPbdFcaQAgXpDmjAgE4k6EBo6E2Tqa2OwWQI+M90u4PZ/KlnJLeV+nkkghFTZ+yxIY9JRSbRmT09wfTfMNDUiIGSysNTTKiZBWGgdWFrEhrwcQLzJsPsr5kEr9G85ufF3yTQQ==</D></RSAKeyValue>";
    Console.WriteLine(decrypt(encrypted_message, example_private_key_xml));
    if (args.Length > 0) {
      string message = args[0];
      Console.WriteLine(decrypt(message, example_private_key_xml));
    }
  }
}
