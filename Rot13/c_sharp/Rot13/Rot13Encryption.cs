using System.Linq;

namespace Rot13;

public class Rot13Encryption
{
    public static string Encrypt(string text)
    {
        var encryptedCharacters = text
            .ToCharArray()
            .Select(EncryptCharacter);

        return string.Join("", encryptedCharacters);
    }

    private static char EncryptCharacter(char character)
    {
        if (IsLowerCaseLatinCharacter(character))
        {
            return RotateCharacter(character, 'a');
        }
        
        if(IsUpperCaseLatinCharacter(character))
        {
            return RotateCharacter(character, 'A');
        }

        return character;
    }

    private static char RotateCharacter(char character, char characterOffset) => 
        (char)((character - characterOffset + 13) % 26 + characterOffset);

    private static bool IsUpperCaseLatinCharacter(char character) => 
        character >= 'A' && character <= 'Z';

    private static bool IsLowerCaseLatinCharacter(char character) => 
        character >= 'a' && character <= 'z';
}
