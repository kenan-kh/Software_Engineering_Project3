namespace LoanApp
{
public class LoanEvaluator
{
      private bool is_Has_Job_And_CridetScore_Gt700_And_Dependents_IsZero(bool hasJob,int creditScore,int dependents){  
        return hasJob && creditScore>=700 && dependents == 0;
      }

      private bool is_Has_Job_And_CridetScore_Gt700_And_Dependents_IsTwoOrLower(bool hasJob,int creditScore,int dependents){
        return hasJob && creditScore>=700 && dependents >= 2;
      }

      private bool is_Has_Job_And_CridetScore_Gt600_And_OwnHouse(bool hasJob,int creditScore,bool ownHouse) {
        return hasJob && creditScore>=600 && ownHouse;
      }

      private bool is_Not_Has_Job_And_CridetScore_Gt750_And_Income_Gt5000_And_OwnHouse(bool hasJob,int creditScore,int income,bool ownHouse){
        return  !hasJob && creditScore>=750 && income > 5000 && ownHouse;
      }

      private bool is_Not_Has_Job_And_CridetScore_Gt650_And_Dependents_IsZero(bool hasJob,int creditScore,int dependents) {
        return !hasJob && creditScore>=650 && dependents == 0;
      }

      private bool isIncomeGreaterThanOrEqualTo2000(int income) => income >= 2000;

      public bool isEligible (bool hasJob,int creditScore,int income,int dependents,bool ownHouse)
      {
        if(is_Has_Job_And_CridetScore_Gt700_And_Dependents_IsZero(hasJob,creditScore,dependents)){
          return true;
        }

        if( is_Not_Has_Job_And_CridetScore_Gt750_And_Income_Gt5000_And_OwnHouse(hasJob,creditScore,income,ownHouse)){
          return true;
        }

        return false;
      }

      public bool isReviewManualy (bool hasJob,int creditScore,int dependents,bool ownHouse)
      {
        if(is_Has_Job_And_CridetScore_Gt600_And_OwnHouse(hasJob,creditScore,ownHouse)){
          return true;
        }

        if( is_Has_Job_And_CridetScore_Gt700_And_Dependents_IsTwoOrLower(hasJob,creditScore,dependents)){
          return true;
        }

        if(is_Not_Has_Job_And_CridetScore_Gt650_And_Dependents_IsZero(hasJob,creditScore,dependents)){
          return true;
        }

        return false;
      }

      public string GetLoanEligibility(int income, bool hasJob, int creditScore, int dependents, bool ownsHouse)
      {
        if(!isIncomeGreaterThanOrEqualTo2000(income)){
          return "Not Eligible";
        }
        else if (isEligible(hasJob,creditScore,income,dependents,ownsHouse)){
          return "Eligible";
        }
        else if (isReviewManualy(hasJob,creditScore,dependents,ownsHouse)){
          return "Review Manually";
        }else{
          return "Not Eligible";
        }
      }
   }
}