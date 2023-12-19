using System.Text;

namespace Herond.Common.Utils;

public static class Base64UrlEncoderBytes
{
    #region Constants
    
    private const char Base64PadCharacter   = '=';
    private const char Base64Character62    = '+';
    private const char Base64Character63    = '/';
    private const char Base64UrlCharacter62 = '-';
    private const char Base64UrlCharacter63 = '_';
    
    private const byte Base64Byte62    = (byte)'+';
    private const byte Base64Byte63    = (byte)'/';
    private const byte Base64PadByte   = (byte)'=';
    private const byte Base64UrlByte62 = (byte)'-';
    private const byte Base64UrlByte63 = (byte)'_';

    #endregion

    #region Methods

    public static byte[] DecodeBytes(byte[] input)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));

        for (int i = 0; i < input.Length; i++)
        {
            // Replace - with +
            if (input[i] == Base64UrlByte62)
                input[i] = Base64Byte62;
            
            // Replace _ with /
            if (input[i] == Base64UrlByte63)
                input[i] = Base64Byte63;
        }

        // Check padding.
        switch (input.Length % 4)
        {
            case 0: // No pad characters.
                break;
            case 2: // Two pad characters.
                Array.Resize(ref input, input.Length + 2);
                input[input.Length - 2] = Base64PadByte;
                input[input.Length - 1] = Base64PadByte;
                break;
            case 3: // One pad character.
                Array.Resize(ref input, input.Length + 1);
                input[input.Length - 1] = Base64PadByte;
                break;
            default:
                throw new FormatException("Invalid Base64 URL encoding.");
        }
        
        return Convert.FromBase64CharArray(Encoding.UTF8.GetChars(input), 0, input.Length);
    }

    public static byte[] EncodeBytes(byte[] input)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));

        // Convert the binary input into Base64 UUEncoded output.
        // Each 3 byte sequence in the source data becomes a 4 byte
        // sequence in the character array.
        long arrayLength = (long) ((4.0d/3.0d) * input.Length);
        
        // If array length is not divisible by 4, go up to the next
        // multiple of 4.
        if (arrayLength % 4 != 0) 
            arrayLength += 4 - arrayLength % 4;
            
        var outputChar = new char[arrayLength];
        Convert.ToBase64CharArray(input, 0, input.Length, outputChar, 0);
        
        for (int i = 0; i < outputChar.Length; i++)
        {
            // Replace + with -
            if (outputChar[i] == Base64Character62)
                outputChar[i] = Base64UrlCharacter62;
            
            // Replace / with _
            if (outputChar[i] == Base64Character63)
                outputChar[i] = Base64UrlCharacter63;
        }
        
        // Check padding.
        // One pad character.
        if (outputChar[outputChar.Length - 1] == Base64PadCharacter)
            Array.Resize(ref outputChar, outputChar.Length - 1);
        // Two pad characters.
        if (outputChar[outputChar.Length - 1] == Base64PadCharacter)
            Array.Resize(ref outputChar, outputChar.Length - 1);
        
        return Encoding.UTF8.GetBytes(outputChar);
    }

    #endregion
}