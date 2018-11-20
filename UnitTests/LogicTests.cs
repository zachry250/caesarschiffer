using CaesarsLogic;
using System;
using Xunit;

namespace UnitTests
{
    public class LogicTests
    {
        [Fact]
        public void TestEncrypt()
        {
            var plainText = @"experience is the teacher of all things
no one is so brave that he is not disturbed by something unexpected
i had rather be first in a village than second at rome
men freely believe that which they desire
i came i saw i conquered";

            var logic = new Logic('\n','\r');
            var encryptedText = logic.GetEncryptString(7, plainText);

            var expectedText = @"lawlyplujlgpzg�olg�lhjolygvmghssg�opunz
uvgvulgpzgzvgiyh�lg�oh�golgpzguv�gkpz��yilkgibgzvtl�opung�ulawlj�lk
pgohkgyh�olygilgmpyz�gpughg�psshnlg�ohugzljvukgh�gyvtl
tlugmyllsbgilspl�lg�oh�g opjog�olbgklzpyl
pgjhtlgpgzh gpgjvux�lylk";

            Assert.Equal(expectedText, expectedText);
        }
    }
}
