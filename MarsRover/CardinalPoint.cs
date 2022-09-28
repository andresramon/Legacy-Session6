using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class CardinalPoint
    {
        private static Dictionary<string, CardinalPointEnum> cardinalDictionary = new Dictionary<string, CardinalPointEnum>()
        {
            {
                "N", CardinalPointEnum.Norte
            },
            {
                "S", CardinalPointEnum.Sur
            },
            {
                "O", CardinalPointEnum.Oeste
            },
            {
                "E", CardinalPointEnum.Este
            }
        };

        public static ICardinal GetCardinalFromString(string cardinalString)
        {
            cardinalDictionary.TryGetValue(cardinalString, out CardinalPointEnum currentOrientation);
            return CardinalPoint.GetCardinal(currentOrientation);
        }

        public static ICardinal GetCardinal(CardinalPointEnum cardinalPointEnum)
        {
            switch (cardinalPointEnum)
            {
                case CardinalPointEnum.Norte:
                    return new Norte();
                case CardinalPointEnum.Oeste:
                    return new Oeste();
                case CardinalPointEnum.Sur:
                    return new Sur();
                case CardinalPointEnum.Este:
                    return new Este();
                default:
                    throw new ArgumentOutOfRangeException(nameof(cardinalPointEnum), cardinalPointEnum, null);
            }
        }
    }
}