
namespace ArtStroke.Common
{
    public static class EntityValidationConstants
    {
        public static class Artwork
        {
            public const int TitleMinLengt = 2;
            public const int TitleMaxLengt = 30;

            public const int TechniqueMinLengt = 4;
            public const int TechniqueMaxLengt = 30;

            public const int MinWidth = 6;
            public const int MaxWidth = 1000;

            public const int MinHeight = 6;
            public const int MaxHeight = 1000;

            public const int ImageUrlMaxLengt = 2048;
        }

        public static class Style
        {
            public const int NameMinLength = 4;

            public const int NameMaxLength = 30;
        }

        public static class PrintDesign
        {
            public const int TitleMinLengt = 2;
            public const int TitleMaxLengt = 30;

            public const int CreatorNameMinLength = 4;

            public const int CreatorNameMaxLength = 30;

            public const int ImageUrlMaxLengt = 2048;

            public const int MinWidth = 6;
            public const int MaxWidth = 1000;

            public const int MinHeight = 6;
            public const int MaxHeight = 1000;
        }


        public static class ArtEvent
        {
            public const int InformationMinLength = 10;

            public const int InformationMaxLength = 400;

            public const int ImageUrlMaxLengt = 2048;
        }

        public static class Artist
        {
            public const int NameMinLength = 4;

            public const int NameMaxLength = 30;

            public const int BiographyMinLength = 30;
            public const int BiographyMaxLength = 3000;

            public const int PhoneNumberMinLength = 7;
            public const int PhoneNumberMaxLength = 15;

        }

        public static class NewTechniqueArt
        {
            public const int TitleMinLength = 2;
            public const int TitleMaxLength = 30;

            public const int DescriptionMinLength = 30;
            public const int DescriptionMaxLength = 3000;

            public const int ImageUrlMaxLengt = 2048;
        }
    }
   
}
