using Xunit;
using LoanApp;

namespace LoanApp.Tests
{
    public class LoanEvaluatorTests
    {
        [Fact]
        public void GetLoanEligibility_Should_Return_NotEligible_When_Income_Low()
        {
            var evaluator=new LoanEvaluator();
            var result=evaluator.GetLoanEligibility(6000, false,800, 2, false);
            Assert.Equal("Not Eligible", result);
        }
         
        [Fact]
        public void GetLoanEligibility_Should_Return_Eligible_When_Income_High_And_is_Not_Has_Job_And_CridetScore_Gt750_And_Income_Gt5000_And_OwnHouse()
        {
            var evaluator=new LoanEvaluator();
            var result=evaluator.GetLoanEligibility(6000, false, 800, 0, true);
            Assert.Equal("Eligible", result);
        }

        [Fact]
        public void GetLoanEligibility_Should_Return_Eligible_When_Income_High_And_is_Has_Job_And_CridetScore_Gt700_And_Dependents_IsZero()
        {
            var evaluator=new LoanEvaluator();
            var result=evaluator.GetLoanEligibility(6000, true, 750, 0, true);
            Assert.Equal("Eligible", result);
        }

        [Fact]
        public void GetLoanEligibility_Should_Return_Review_Manually_When_Income_High_And_is_Not_Has_Job_And_CridetScore_Gt650_And_Dependents_IsZero()
        {
            var evaluator=new LoanEvaluator();
            var result=evaluator.GetLoanEligibility(6000, false, 650, 0, false);
            Assert.Equal("Review Manually", result);
        }

        [Fact]
        public void GetLoanEligibility_Should_Return_Review_Manually_When_Income_High_And_is_Has_Job_And_CridetScore_Gt700_And_Dependents_IsTwoOrLower()
        {
            var evaluator=new LoanEvaluator();
            var result=evaluator.GetLoanEligibility(6000, true, 700, 2, false);
            Assert.Equal("Review Manually", result);
        }

        [Fact]
        public void GetLoanEligibility_Should_Return_Review_Manually_When_Income_High_And_is_Has_Job_And_CridetScore_Gt600_And_OwnHouse()
        {
            var evaluator=new LoanEvaluator();
            var result=evaluator.GetLoanEligibility(6000, true, 700, 2, true);
            Assert.Equal("Review Manually", result);
        }
    }
}