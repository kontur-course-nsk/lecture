namespace TestingTasks.Infrastructure
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class GenerateIncorrectTests
    {
        [Test]
        public void Generate()
        {
            var impls = IncorrectImplementationHelper.GetTypes();
            var code = string.Join(Environment.NewLine,
                impls.Select(imp => $"public class {imp.Name}_Tests : {nameof(IncorrectImplementation_TestsBase)} {{}}")
            );
            Console.WriteLine(code);
        }

        [Test]
        public void CheckAllTestsAreInPlace()
        {
            var implTypes = IncorrectImplementationHelper.GetTypes();
            var testedImpls = IncorrectImplementationHelper.GetTests()
                .Select(it => it.CreateTasks())
                .ToArray();

            foreach (var impl in implTypes)
            {
                Assert.NotNull(testedImpls.SingleOrDefault(it => it.GetType().FullName == impl.FullName),
                    "Single implementation of tests for {0} not found. Regenerate tests with test above!",
                    impl.FullName);
            }
        }
    }

    #region Generated with test above

    public class BeSumOfAbs_WhenBothPositive_Tests : IncorrectImplementation_TestsBase
    {
    }

    public class BeSumOfAbs_WhenFirstNegative_Tests : IncorrectImplementation_TestsBase
    {
    }

    public class BeSumOfAbs_WhenSecondNegative_Tests : IncorrectImplementation_TestsBase
    {
    }

    public class BeSumOfAbs_WhenBothNegative_Tests : IncorrectImplementation_TestsBase
    {
    }

    public class DecreaseFirst_WhenMoveLeft_Tests : IncorrectImplementation_TestsBase
    {
    }

    public class IncreaseFirst_WhenMoveRight_Tests : IncorrectImplementation_TestsBase
    {
    }

    public class IncreaseSecond_WhenMoveForward_Tests : IncorrectImplementation_TestsBase
    {
    }

    public class DecreaseSecond_WhenMoveBack_Tests : IncorrectImplementation_TestsBase
    {
    }

    public class IncreaseThird_WhenMoveUp_Tests : IncorrectImplementation_TestsBase
    {
    }

    public class DecreaseThird_WhenMoveDown_Tests : IncorrectImplementation_TestsBase
    {
    }

    public class ExcludeDuplicate_WhenNotFirstElementIsDuplicate_Tests : IncorrectImplementation_TestsBase
    {
    }

    public class ExcludeDuplicate_WhenNotLastElementIsDuplicate_Tests : IncorrectImplementation_TestsBase
    {
    }

    public class Fail_WhenEmptyArray_Tests : IncorrectImplementation_TestsBase
    {
    }

    public class ExcludeDuplicate_WhenElementsNotTogether_Tests : IncorrectImplementation_TestsBase
    {
    }

    public class ExcludeDuplicates_WhenDuplicatesCountIsLarge_Tests : IncorrectImplementation_TestsBase
    {
    }

    #endregion
}