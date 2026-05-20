namespace EasyNetQ.Tests;

/// <summary>
/// Tests covering the first ten methods of <see cref="CyclomaticComplexityExamples"/>.
/// Methods 11-22 are intentionally left without tests.
/// </summary>
public class CyclomaticComplexityExamplesTests
{
    // ── CC=1  Add ─────────────────────────────────────────────────────────────

    public class When_using_Add
    {
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(-1, 1, 0)]
        [InlineData(0, 0, 0)]
        [InlineData(int.MaxValue, 0, int.MaxValue)]
        public void Should_return_sum(int a, int b, int expected)
        {
            CyclomaticComplexityExamples.Add(a, b).Should().Be(expected);
        }
    }

    // ── CC=2  GetSign ─────────────────────────────────────────────────────────

    public class When_using_GetSign
    {
        [Theory]
        [InlineData(5, "non-negative")]
        [InlineData(0, "non-negative")]
        [InlineData(-1, "negative")]
        [InlineData(-999, "negative")]
        public void Should_classify_sign(int n, string expected)
        {
            CyclomaticComplexityExamples.GetSign(n).Should().Be(expected);
        }
    }

    // ── CC=3  ClassifyNumber ──────────────────────────────────────────────────

    public class When_using_ClassifyNumber
    {
        [Theory]
        [InlineData(-10, "negative")]
        [InlineData(0, "zero")]
        [InlineData(42, "positive")]
        public void Should_classify_number(int n, string expected)
        {
            CyclomaticComplexityExamples.ClassifyNumber(n).Should().Be(expected);
        }
    }

    // ── CC=4  GetGrade ────────────────────────────────────────────────────────

    public class When_using_GetGrade
    {
        [Theory]
        [InlineData(95, "A")]
        [InlineData(90, "A")]
        [InlineData(85, "B")]
        [InlineData(80, "B")]
        [InlineData(75, "C")]
        [InlineData(70, "C")]
        [InlineData(69, "F")]
        [InlineData(0, "F")]
        public void Should_return_grade(int score, string expected)
        {
            CyclomaticComplexityExamples.GetGrade(score).Should().Be(expected);
        }
    }

    // ── CC=5  GetLetterGrade ──────────────────────────────────────────────────

    public class When_using_GetLetterGrade
    {
        [Theory]
        [InlineData(100, "A")]
        [InlineData(80, "B")]
        [InlineData(70, "C")]
        [InlineData(60, "D")]
        [InlineData(59, "F")]
        public void Should_return_letter_grade(int score, string expected)
        {
            CyclomaticComplexityExamples.GetLetterGrade(score).Should().Be(expected);
        }
    }

    // ── CC=6  CalculateShippingCost ───────────────────────────────────────────

    public class When_using_CalculateShippingCost
    {
        [Theory]
        [InlineData(0.5, 5.0)]
        [InlineData(1.0, 5.0)]
        [InlineData(3.0, 10.0)]
        [InlineData(5.0, 10.0)]
        [InlineData(7.5, 15.0)]
        [InlineData(10.0, 15.0)]
        [InlineData(15.0, 20.0)]
        [InlineData(20.0, 20.0)]
        [InlineData(50.0, 30.0)]
        public void Should_return_correct_cost(double weight, double expected)
        {
            CyclomaticComplexityExamples.CalculateShippingCost(weight).Should().Be(expected);
        }

        [Fact]
        public void Should_throw_for_zero_weight()
        {
            var act = () => CyclomaticComplexityExamples.CalculateShippingCost(0);
            act.Should().Throw<ArgumentException>();
        }
    }

    // ── CC=7  GetDayName ──────────────────────────────────────────────────────

    public class When_using_GetDayName
    {
        [Theory]
        [InlineData(1, "Monday")]
        [InlineData(2, "Tuesday")]
        [InlineData(3, "Wednesday")]
        [InlineData(4, "Thursday")]
        [InlineData(5, "Friday")]
        [InlineData(6, "Saturday")]
        [InlineData(7, "Sunday")]
        [InlineData(0, "Sunday")]
        public void Should_return_day_name(int dayOfWeek, string expected)
        {
            CyclomaticComplexityExamples.GetDayName(dayOfWeek).Should().Be(expected);
        }
    }

    // ── CC=8  ComputeTax ──────────────────────────────────────────────────────

    public class When_using_ComputeTax
    {
        [Theory]
        [InlineData(0, "US", 0)]
        [InlineData(-100, "US", 0)]
        [InlineData(5000, "US", 500)]
        [InlineData(30000, "US", 6600)]
        [InlineData(100000, "US", 37000)]
        [InlineData(10000, "UK", 0)]
        [InlineData(30000, "UK", 6000)]
        [InlineData(60000, "UK", 24000)]
        [InlineData(50000, "CA", 7500)]
        public void Should_compute_correct_tax(double income, string country, double expected)
        {
            CyclomaticComplexityExamples.ComputeTax(income, country).Should().BeApproximately(expected, 0.01);
        }
    }

    // ── CC=9  GetProductCategory ──────────────────────────────────────────────

    public class When_using_GetProductCategory
    {
        [Theory]
        [InlineData(null, "unknown")]
        [InlineData("", "unknown")]
        [InlineData("ABC", "Type-A Small")]
        [InlineData("ABCDE", "Type-A Medium")]
        [InlineData("ABCDEF", "Type-A Large")]
        [InlineData("BCD", "Type-B Small")]
        [InlineData("BCDEF", "Type-B Medium")]
        [InlineData("BCDEFG", "Type-B Large")]
        [InlineData("CAT", "Type-C")]
        [InlineData("XYZ", "Other")]
        public void Should_return_product_category(string code, string expected)
        {
            CyclomaticComplexityExamples.GetProductCategory(code).Should().Be(expected);
        }
    }

    // ── CC=10  ValidateEmail ──────────────────────────────────────────────────

    public class When_using_ValidateEmail
    {
        [Theory]
        [InlineData("user@example.com", true)]
        [InlineData("a@b.io", true)]
        [InlineData("", false)]
        [InlineData(null, false)]
        [InlineData("no-at-sign", false)]
        [InlineData("@example.com", false)]
        [InlineData("user@", false)]
        [InlineData("user @example.com", false)]
        [InlineData("user@nodot", false)]
        [InlineData("user@example.", false)]
        public void Should_validate_email(string email, bool expected)
        {
            CyclomaticComplexityExamples.ValidateEmail(email).Should().Be(expected);
        }
    }
}
