
using System.Numerics;

BigInteger num = 2;
while (true)
{
    if (IsPrime(num) && (IsAscending(num) || IsDescending(num)))
    {
        Console.WriteLine(num);
    }
    num++;
}


bool IsPrime(BigInteger x)
{
    if (x < 2)
    {
        return false;
    }

    var sqrt = Sqrt(x) + 1;
    for (BigInteger i = 2; i < sqrt; i++)
    {
        if (x % i == 0)
        {
            return false;
        }
    }

    return true;
}

BigInteger Sqrt(BigInteger x)
{
    if (x == 0)
    {
        return 0;
    }

    if (x <= 0)
    {
        throw new ArithmeticException("NaN");
    }

    var bitLength = Convert.ToInt32(Math.Ceiling(BigInteger.Log(x, 2)));
    var root = BigInteger.One << (bitLength / 2);

    while (!IsSqrt(x, root))
    {
        root += x / root;
        root /= 2;
    }

    return root;
}

bool IsSqrt(BigInteger x, BigInteger root)
{
    var lowerBound = root * root;
    var upperBound = (root + 1) * (root + 1);
    return (x >= lowerBound && x <= upperBound);
}

bool IsAscending(BigInteger x)
{
    var lastDigit = x % 10;
    x /= 10;
    var digit = x % 10;

    if (digit == 0) // single digit
    {
        return false;
    }

    // while ((lastDigit == digit + 1 || lastDigit == digit) && !(lastDigit == 0 && digit == 0))
    while (lastDigit == digit + 1)
    {
        lastDigit = digit;
        x /= 10;
        digit = x % 10;
    }

    return x == 0;
}

bool IsDescending(BigInteger x)
{
    var lastDigit = x % 10;
    x /= 10;
    var digit = x % 10;

    if (digit == 0) // single digit
    {
        return false;
    }

    // while ((lastDigit == digit - 1 || lastDigit == digit) && !(lastDigit == 0 && digit == 0))
    while (lastDigit == digit - 1)
    {
        lastDigit = digit;
        x /= 10;
        digit = x % 10;
    }

    return x == 0;
}
