using Xunit;

namespace CI_CD_Group_8.Tests
{
    public class PersonnummerValidatorTests
    {
        [Theory]
        [InlineData("9001010017")]   // kan bytas om den inte stämmer
        [InlineData("900101-0017")]  // samma men med bindestreck
        public void Valid_ReturnsTrue(string pnr)
        {
            Assert.True(CI_CD_Group_8.PersonnummerValidator.IsValid(pnr));
        }

        [Theory]
        [InlineData("900101-0018")] // fel kontrollsiffra
        [InlineData("990231-1234")] // ogiltigt datum
        [InlineData("abcdef-1234")] // bokstäver
        [InlineData("")]            // tom
        [InlineData("123")]         // för kort
        public void Invalid_ReturnsFalse(string pnr)
        {
            Assert.False(CI_CD_Group_8.PersonnummerValidator.IsValid(pnr));
        }
    }
}
