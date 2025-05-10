using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using Dapper;
using MySqlConnector;

namespace BankaSpotNew.App_Code
{
    public class DataAccess
    {
        private readonly string _connectionString;

        public DataAccess()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        }

        public void Execute(string sql, object parameters = null)
        {
            var dynamicParameters = new DynamicParameters();
            if (parameters != null)
            {
                var properties = parameters.GetType().GetProperties();
                foreach (var property in properties)
                {
                    dynamicParameters.Add(property.Name, property.GetValue(parameters));
                }
            }
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Execute(sql, dynamicParameters);
            }
        }

        public T QuerySingleOrDefault<T>(string sql, object parameters = null)
        {
            var dynamicParameters = new DynamicParameters();
            if (parameters != null)
            {
                var properties = parameters.GetType().GetProperties();
                foreach (var property in properties)
                {
                    dynamicParameters.Add(property.Name, property.GetValue(parameters));
                }
            }
            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.QuerySingleOrDefault<T>(sql, dynamicParameters);
            }
        }

        public IEnumerable<T> Query<T>(string sql, object parameters = null)
        {
            var dynamicParameters = new DynamicParameters();
            if (parameters != null)
            {
                var properties = parameters.GetType().GetProperties();
                foreach (var property in properties)
                {
                    dynamicParameters.Add(property.Name, property.GetValue(parameters));
                }
            }
            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<T>(sql, dynamicParameters);
            }
        }
        public void ExecuteSP(string spName, object parameters = null)
        {
            var dynamicParameters = new DynamicParameters();
            if (parameters != null)
            {
                var properties = parameters.GetType().GetProperties();
                foreach (var property in properties)
                {
                    dynamicParameters.Add(property.Name, property.GetValue(parameters));
                }
            }
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Execute(spName, dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        public T QuerySingleOrDefaultSP<T>(string spName, object parameters = null)
        {
            var dynamicParameters = new DynamicParameters();
            if (parameters != null)
            {
                var properties = parameters.GetType().GetProperties();
                foreach (var property in properties)
                {
                    dynamicParameters.Add(property.Name, property.GetValue(parameters));
                }
            }
            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.QuerySingleOrDefault<T>(spName, dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<T> QuerySP<T>(string spName, object parameters = null)
        {
            var dynamicParameters = new DynamicParameters();
            if (parameters != null)
            {
                var properties = parameters.GetType().GetProperties();
                foreach (var property in properties)
                {
                    dynamicParameters.Add(property.Name, property.GetValue(parameters));
                }
            }
            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<T>(spName, dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }
        public void ExecuteDynamic(string sql, DynamicParameters parameters = null)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Execute(sql, parameters);
            }
        }

        public T QuerySingleOrDefaultDynamic<T>(string sql, DynamicParameters parameters = null)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.QuerySingleOrDefault<T>(sql, parameters);
            }
        }

        public List<T> QueryDynamic<T>(string sql, DynamicParameters parameters = null)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<T>(sql, parameters).ToList();
            }
        }
        public void ExecuteSPDynamic(string spName, DynamicParameters parameters = null)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public T QuerySingleOrDefaultSPDynamic<T>(string spName, DynamicParameters parameters = null)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.QuerySingleOrDefault<T>(spName, parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public List<T> QuerySPListDynamic<T>(string spName, DynamicParameters parameters = null)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<T>(spName, parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public IEnumerable<T> QuerySPDynamic<T>(string spName, DynamicParameters parameters = null)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<T>(spName, parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public Employee_Dashboard QueryMultipleSPDynamic<T>(string spName, DynamicParameters parameters = null)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                var result = connection.QueryMultiple(spName, parameters, commandType: CommandType.StoredProcedure);

                var procedureResult = new Employee_Dashboard();
                var dashboardData = result.ReadFirst();
                procedureResult.TotalPayout = dashboardData?.TotalPayout;
                procedureResult.TotalCasesPending = dashboardData?.TotalCasesPending;
                procedureResult.TotalCasesCompleted = dashboardData?.TotalCasesCompleted;
                procedureResult.TodaysCases = dashboardData?.TodaysCases;
                procedureResult.TotalCasesRejected = dashboardData?.TotalCasesRejected;

                var casesData = result.Read().FirstOrDefault();
                procedureResult.TotalCases = casesData?.TotalCases;

                procedureResult.MonthWisePayout = result.Read().ToList();

                return procedureResult;
            }
        }
        public Employee_Dashboard QueryMultipleSPDynamicBranch<T>(string spName, DynamicParameters parameters = null)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                var result = connection.QueryMultiple(spName, parameters, commandType: CommandType.StoredProcedure);

                var procedureResult = new Employee_Dashboard();
                var dashboardData = result.Read().FirstOrDefault();
                procedureResult.TotalPayout = dashboardData?.TotalPayout;
                procedureResult.TotalCasesPending = dashboardData?.TotalCasesPending;
                procedureResult.TotalCasesCompleted = dashboardData?.TotalCasesCompleted;
                procedureResult.TodaysCases = dashboardData?.TodaysCases;
                procedureResult.TotalCasesRejected = dashboardData?.TotalCasesRejected;

                var casesData = result.Read().FirstOrDefault();
                procedureResult.TotalCases = casesData?.TotalCases;

                return procedureResult;
            }
        }
    }
    public class DataAccessBankaspotWeb
    {
        private readonly string _connectionString;

        public DataAccessBankaspotWeb()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["cn2"].ConnectionString;
        }

        public void Execute(string sql, object parameters = null)
        {
            var dynamicParameters = new DynamicParameters();
            if (parameters != null)
            {
                var properties = parameters.GetType().GetProperties();
                foreach (var property in properties)
                {
                    dynamicParameters.Add(property.Name, property.GetValue(parameters));
                }
            }
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Execute(sql, dynamicParameters);
            }
        }

        public T QuerySingleOrDefault<T>(string sql, object parameters = null)
        {
            var dynamicParameters = new DynamicParameters();
            if (parameters != null)
            {
                var properties = parameters.GetType().GetProperties();
                foreach (var property in properties)
                {
                    dynamicParameters.Add(property.Name, property.GetValue(parameters));
                }
            }
            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.QuerySingleOrDefault<T>(sql, dynamicParameters);
            }
        }

        public IEnumerable<T> Query<T>(string sql, object parameters = null)
        {
            var dynamicParameters = new DynamicParameters();
            if (parameters != null)
            {
                var properties = parameters.GetType().GetProperties();
                foreach (var property in properties)
                {
                    dynamicParameters.Add(property.Name, property.GetValue(parameters));
                }
            }
            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<T>(sql, dynamicParameters);
            }
        }
        public void ExecuteSP(string spName, object parameters = null)
        {
            var dynamicParameters = new DynamicParameters();
            if (parameters != null)
            {
                var properties = parameters.GetType().GetProperties();
                foreach (var property in properties)
                {
                    dynamicParameters.Add(property.Name, property.GetValue(parameters));
                }
            }
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Execute(spName, dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        public T QuerySingleOrDefaultSP<T>(string spName, object parameters = null)
        {
            var dynamicParameters = new DynamicParameters();
            if (parameters != null)
            {
                var properties = parameters.GetType().GetProperties();
                foreach (var property in properties)
                {
                    dynamicParameters.Add(property.Name, property.GetValue(parameters));
                }
            }
            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.QuerySingleOrDefault<T>(spName, dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<T> QuerySP<T>(string spName, object parameters = null)
        {
            var dynamicParameters = new DynamicParameters();
            if (parameters != null)
            {
                var properties = parameters.GetType().GetProperties();
                foreach (var property in properties)
                {
                    dynamicParameters.Add(property.Name, property.GetValue(parameters));
                }
            }
            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<T>(spName, dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }
        public void ExecuteDynamic(string sql, DynamicParameters parameters = null)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Execute(sql, parameters);
            }
        }

        public T QuerySingleOrDefaultDynamic<T>(string sql, DynamicParameters parameters = null)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.QuerySingleOrDefault<T>(sql, parameters);
            }
        }

        public List<T> QueryDynamic<T>(string sql, DynamicParameters parameters = null)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<T>(sql, parameters).ToList();
            }
        }
        public void ExecuteSPDynamic(string spName, DynamicParameters parameters = null)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public T QuerySingleOrDefaultSPDynamic<T>(string spName, DynamicParameters parameters = null)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.QuerySingleOrDefault<T>(spName, parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public List<T> QuerySPListDynamic<T>(string spName, DynamicParameters parameters = null)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<T>(spName, parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public IEnumerable<T> QuerySPDynamic<T>(string spName, DynamicParameters parameters = null)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<T>(spName, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
    public class Branch_Add
    {
        public int Id { get; set; }
        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public string BranchManager { get; set; }
        public string BranchLocation { get; set; }
        public string BranchAddress { get; set; }
        public string BranchMonthTarget { get; set; }
        public string BranchProTraget { get; set; }
        public string BranchMobileNo { get; set; }
        public string BranchPassword { get; set; }
        public DateTime CreatedOn { get; set; }
        public int Role { get; set; }
        public int RegionId { get; set; }
    }
    public class Region_Add
    {
        public int Id { get; set; }
        public string RegionIdNo { get; set; }
        public string RegionName { get; set; }
        public string RegionalManager { get; set; }
        public string RegionLocation { get; set; }
        public string RegionAddress { get; set; }
        public string RegionMonthTarget { get; set; }
        public string RegionProTarget { get; set; }
        public string RegionMobileNumber { get; set; }
        public string RegionPassword { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    public class Employee_Add
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string EmpLocation { get; set; }
        public string Address { get; set; }
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public string IFSCCode { get; set; }
        public string BankBranchAddress { get; set; }
        public int BranchId { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string ProIncentivePercentage { get; set; }
        public string MonthTarget { get; set; }
        public string EmpPassword { get; set; }
        public DateTime CreatedOn { get; set; }
        public string EmployeeStatus { get; set; }//ext1
        public string ext2 { get; set; }//designation
        public string BranchName { get; set; }
        public string ext3 { get; set; }//date of anniversary
        public string ext4 { get; set; }//date of birth
    }
    public class Product_Add
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double FreelancerCom { get; set; }
        public double EmployeeCom { get; set; }
        public double ConnectorCom { get; set; }
        public string ext1 { get; set; }//marketing emp comm
        public string ext2 { get; set; }
        public string ext3 { get; set; }
        public string ext4 { get; set; }
    }
    public class Connector_Add
    {
        public int Id { get; set; }
        public string ConnectorId { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string ConLocation { get; set; }
        public string Profile { get; set; }
        public string Address { get; set; }
        public string PanNo { get; set; }
        public string AdharNo { get; set; }
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public string IFSCCode { get; set; }
        public string BankBranchAddress { get; set; }
        public int BranchId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Password { get; set; }
        public string ext1 { get; set; }//Pan Card
        public string ext2 { get; set; }//Adhar Card
        public string ext3 { get; set; }//Cancel Check
        public string EmpName { get; set; }
        public int CaseCount { get; set; }
        public string ext4 { get; set; }//active inactive status
        public int totalCases { get; set; }
        public int disbursedCases { get; set; }
        public int rejectedCases { get; set; }
        public int activeCases { get; set; }
        public string ConnectorPic { get; set; }
        public string BranchName { get; set; }
        public int MarketEmpId { get; set; }
        public string MarketEmpName { get; set; }
        public DateTime DOA { get; set; }
        public DateTime DOB { get; set; }
    }
    public class Case_Add
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int ProductReq { get; set; }
        public double AmountReq { get; set; }
        public string CustomerProfile { get; set; }
        public string MonthlyIncome { get; set; }
        public int ConnectorId { get; set; }
        public int EmpId { get; set; }
        public int BranchId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public string ProductName { get; set; }
        public string EmpName { get; set; }
        public string ext1 { get; set; }
        public string BankName { get; set; }
        public string BankEmpName { get; set; }
        public string BankEmpContactNo { get; set; }
        public string LeadHandling { get; set; }
        public string LeadGenerated { get; set; }
        public string LeadGenContactNo { get; set; }
        public DateTime FileLogInDate { get; set; }
        public DateTime ExpectedDisbursedDate { get; set; }
        public double Incentive { get; set; }
        public string ext5 { get; set; }//Amount Disbursed
        public string ext6 { get; set; }//Loan Account No.
        public DateTime DisbursedDate { get; set; }
        public string ext2 { get; set; }//sanctioned amount
        public string ConnectorName { get; set; }
        public string ConnectorMobileNo { get; set; }
        public string ext3 { get; set; }//Freelancer Id
        public string FreelancerName { get; set; }
        public string ext4 { get; set; }//marketing emp id
        public string MarketingEmpName { get; set; }
        public string CaseBookedIn { get; set; }
        public string BranchName { get; set; }
        public string EmpMobileNo { get; set; }
    }
    public class Log
    {
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        private readonly string _logFilePath;
        private const long MaxFileSizeBytes = 1000000;

        public Log(string logFileName)
        {
            // Get the project directory and append the Logs folder and log file name
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string logsFolder = Path.Combine(projectDirectory, "Logs");
            _logFilePath = Path.Combine(logsFolder, logFileName);
        }

        public void LogError(Exception ex)
        {
            //DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

            //string logMessage = $"{indianTime}: {ex}";

            //FileInfo fileInfo = new FileInfo(_logFilePath);

            //if (fileInfo.Exists && fileInfo.Length >= MaxFileSizeBytes)
            //{
            //    // Backup the current log file before clearing it
            //    string backupFilePath = $"{_logFilePath}.{indianTime:yyyyMMddHHmmss}.bak";
            //    File.Move(_logFilePath, backupFilePath);

            //    // Clear the log file and write the new log message
            //    File.WriteAllText(_logFilePath, logMessage);
            //}
            //else
            //{
            //    // Append the new log message to the existing log file
            //    string existingContent = fileInfo.Exists ? File.ReadAllText(_logFilePath) : "";
            //    string newContent = $"{logMessage}\n\n{existingContent}";
            //    File.WriteAllText(_logFilePath, newContent);
            //}
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

            string FileName = indianTime.ToString("yyyyMMdd") + ".txt";
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string FullFileName = Path.Combine(projectDirectory, "Logs", FileName);

            string logMessage = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE) + " " + ex;

            FileInfo fileInfo = new FileInfo(FullFileName);

            if (fileInfo.Exists && fileInfo.Length >= MaxFileSizeBytes)
            {
                // Backup the current log file before clearing it
                string backupFilePath = FullFileName + "." + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bak";
                File.Move(FullFileName, backupFilePath);

                // Clear the log file and write the new log message
                File.WriteAllText(FullFileName, logMessage);
            }
            else
            {
                // Append the new log message to the existing log file
                string existingContent = fileInfo.Exists ? File.ReadAllText(FullFileName) : "";
                string newContent = logMessage + "\n\n" + existingContent;
                File.WriteAllText(FullFileName, newContent);
            }
        }
    }
    public class Case_Status_Add
    {
        public int Id { get; set; }
        public string CaseStatus { get; set; }
    }
    public class Case_Status_History
    {
        public int Id { get; set; }
        public int CaseId { get; set; }
        public DateTime DateAdded { get; set; }
        public int EmpId { get; set; }
        public string NewStatus { get; set; }
        public string PreStatus { get; set; }
        public string CaseFile { get; set; }
        public string Remarks { get; set; }
        public string BankName { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string ext1 { get; set; }//case booked in
        public string ext5 { get; set; }//Amount Disbursed
        public string ext2 { get; set; }//sanctioned amount
        public string ProductName { get; set; }
        public string LoanAccNo { get; set; }
    }
    public class Payouts_Add
    {
        public int Id { get; set; }
        public int CaseId { get; set; }
        public DateTime PayDate { get; set; }
        public int UserId { get; set; }
        public string UserType { get; set; }
        public double PayAmount { get; set; }
        public string EmpName { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public double AmountDisbursed { get; set; }
        public string ext1 { get; set; }//payout status 0 for pending 1 for paid
        public string ext2 { get; set; }// payout date
        public string BranchLocation { get; set; }
        public string ConnectorName { get; set; }
        public string ext3 { get; set; }//extra payout
        public string ext4 { get; set; }//extra deduction
        public string Month { get; set; }
        public double Payout { get; set; }
        public double OriginalPayout { get; set; }
        public double TDS { get; set; }
        public string ConnectorPanNo { get; set; }
        public string FreeLancerName { get; set; }
        public double ConnectorCom { get; set; }
        public double FreelancerCom { get; set; }
        public string MobileNo { get; set; }
        public string AnyReason { get; set; }
        public DateTime DisbursedDate { get; set; }
    }
    public class Employee_Dashboard
    {
        public dynamic TotalPayout { get; set; }
        public dynamic TotalCasesPending { get; set; }
        public dynamic TotalCasesCompleted { get; set; }
        public dynamic TotalCasesRejected { get; set; }
        public dynamic TodaysCases { get; set; }
        public dynamic TotalCases { get; set; }
        public List<dynamic> MonthWisePayout { get; set; }
    }
    public class Employee_Target
    {
        public int Id { get; set; }
        public int Proid { get; set; }
        public int Empid { get; set; }
        public double EmpTarget { get; set; }
        public string ProductName { get; set; }
        public double Incentive { get; set; }
        public double ext5 { get; set; }//Amount Disbursed
        public double ShortFall { get; set; }
        public string ext1 { get; set; }//dateadded employee target
        public string EmployeeName { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime DisbursedDate { get; set; }
        public List<Case_Add> CaseList { get; set; }
        public double TargetAchieved { get; set; }
        public double IncentiveEarned { get; set; }
    }
    public class Connector_Withdrawal
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime WithdrawalDate { get; set; }
        public double WithdrawalAmount { get; set; }
        public string WithdrawalType { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
        public int Incentive { get; set; }
    }
    public class Freelancer_Withdrawal
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime WithdrawalDate { get; set; }
        public double WithdrawalAmount { get; set; }
        public string WithdrawalType { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
        public int Incentive { get; set; }
    }
    public class Employee_Withdrawal
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime WithdrawalDate { get; set; }
        public double WithdrawalAmount { get; set; }
        public string WithdrawalType { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
    }
    public class Freelancer_Add
    {
        public int Id { get; set; }
        public string FreelancerId { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string FreelancerLocation { get; set; }
        public string Profile { get; set; }
        public string Address { get; set; }
        public string PanNo { get; set; }
        public string AdharNo { get; set; }
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public string IFSCCode { get; set; }
        public string BankBranchAddress { get; set; }
        public int BranchId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Password { get; set; }
        public string ext1 { get; set; }//Pan Card
        public string ext2 { get; set; }//Adhar Card
        public string ext3 { get; set; }//Cancel Check
        public int CaseCount { get; set; }
        public string ext4 { get; set; }//active inactive status
        public int totalCases { get; set; }
        public int disbursedCases { get; set; }
        public int rejectedCases { get; set; }
        public int activeCases { get; set; }
        public string FreelancerPic { get; set; }
        public int MarketEmpId { get; set; }
        public string BranchName { get; set; }
        public string EmpName { get; set; }
        public string MarketEmpName { get; set; }
        public DateTime DOA { get; set; }
        public DateTime DOB { get; set; }
    }
    public class BankCodes_Add
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string ProductName { get; set; }
        public string CodeName { get; set; }
        public string BankCode { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    public class Sliders_Add
    {
        public int Id { get; set; }
        public string SliderImage { get; set; }
    }
    public class Employee_Case_History
    {
        public int Id { get; set; }
        public int CaseId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    public class Marketing_Employee_Add
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string EmpLocation { get; set; }
        public string Address { get; set; }
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public string IFSCCode { get; set; }
        public string BankBranchAddress { get; set; }
        public int BranchId { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string ProIncentivePercentage { get; set; }
        public string MonthTarget { get; set; }
        public string EmpPassword { get; set; }
        public DateTime CreatedOn { get; set; }
        public string EmployeeStatus { get; set; }//ext1
        public string ext3 { get; set; }//date of anniversary
        public string ext4 { get; set; }//date of birth
    }
    public class Marketing_Employee_Withdrawal
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime WithdrawalDate { get; set; }
        public double WithdrawalAmount { get; set; }
        public string WithdrawalType { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
        public string ext1 { get; set; }
        public string ext2 { get; set; }
    }
    public class AccountantModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    public class ExpenseModel
    {
        public int Id { get; set; }
        public int CaseId { get; set; }
        public int AccountantId { get; set; }
        public string PFCollected { get; set; }
        public string PayoutSlab { get; set; }
        public double Payout { get; set; }
        public double TDS { get; set; }
        public double NetPayout { get; set; }
        public double GST { get; set; }
        public double GrossPayout { get; set; }
        public string GSTStatus { get; set; }
        public double AmtCredBank { get; set; }
        public double AmtDifference { get; set; }
        public string BillRaised { get; set; }
        public string BillNo { get; set; }
        public string PayoutStatus { get; set; }
        public string PayoutRecievedIn { get; set; }
        public DateTime BillRecDate { get; set; }
        public DateTime BankInRecDate { get; set; }
        public double AddPayAmt { get; set; }
        public string AddPayAmtRecPerson { get; set; }
        public string AddPayStatus { get; set; }
        public DateTime AddPayDate { get; set; }
        public double LGPayout { get; set; }
        public double LGExtraPayout { get; set; }
        public string LGPayoutStatus { get; set; }
        public DateTime LGPayoutDate { get; set; }
        public double StaffPayout { get; set; }
        public string StaffPayoutStatus { get; set; }
        public DateTime StaffPayoutDate { get; set; }
        public double CaseExpenses { get; set; }
        public double NetEarning { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime GstAmtRecDate { get; set; }
        public DateTime PayoutRecDate { get; set; }
    }
    public class EmployeeProductWiseTargetModel
    {
        public double DisbursedAmount { get; set; }
        public DateTime DisbursedDate { get; set; }
        public int CaseId { get; set; }
    }
    public class BankerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public int ProductId { get; set; }
        public string City { get; set; }
        public string AreaCovered { get; set; }
        public int LocationId { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ProductName { get; set; }
        public string RegionName { get; set; }
        public string BankName { get; set; }
        public string Designation { get; set; }
    }
    public class CustomerModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerMobileNo { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int BranchId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string EmailId { get; set; }
        public int IsLoanAgent { get; set; }
        public int Status { get; set; }
        public string Password { get; set; }
        public int ReferId { get; set; }
        public string ReferIdType { get; set; }
        public string Type { get; set; }
        public string BranchName { get; set; }
    }
    public class LoanModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string LoanReq { get; set; }
        public double AmountReq { get; set; }
        public string Profile { get; set; }
        public string MonthlyIncome { get; set; }
        public string City { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ProductId { get; set; }
        public int BranchId { get; set; }
        public string Type { get; set; }
        public string CustomerName { get; set; }
        public string CustomerMobileNo { get; set; }
        public string CustomerType { get; set; }
    }
    public class ConnectorMappingHistoryModel
    {
        public int Id { get; set; }
        public int ConnectorId { get; set; }
        public DateTime MappingDate { get; set; }
        public int OldBranchId { get; set; }
        public int OldEmpId { get; set; }
        public int OldMarketEmpId { get; set; }
        public int NewBranchId { get; set; }
        public int NewEmpId { get; set; }
        public int NewMarketEmpId { get; set; }
        public string MappedBy { get; set; }
    }
    public class EmployeePayoutSlabModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public double MinAmount { get; set; }
        public double MaxAmount { get; set; }
        public double Payout { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    public class ConnectorPayoutSlabModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public double MinAmount { get; set; }
        public double MaxAmount { get; set; }
        public double Payout { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    public class SubconnectorPayoutModel
    {
        public int Id { get; set; }
        public int CaseId { get; set; }
        public double PayoutAmount { get; set; }
        public string Remarks { get; set; }
        public string AddedByType { get; set; }
        public int AddedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int SCId { get; set; }
        public string Name { get; set; }
        public string ProductName { get; set; }
        public double AmountDisbursed { get; set; }
    }
    public class StaffModel
    {
        public int Id { get; set; }
        public string StaffName { get; set; }
        public string StaffMobileNo { get; set; }
        public int ProductId { get; set; }
        public string StaffEmailId { get; set; }
        public string StaffAddress { get; set; }
        public DateTime CreatedOn { get; set; }
        public int BranchId { get; set; }
        public string ProductName { get; set; }
    }
    public class FreelancerProductPayoutModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int FreelancerId { get; set; }
        public double PayoutPercent { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ProductName { get; set; }
    }
    public class LoanQueryModel
    {
        public int id
        {
            get; set;
        }
        public String prorequired
        {
            get; set;
        }
        public String name
        {
            get; set;
        }
        public String protype
        {
            get; set;
        }
        public String profile
        {
            get; set;
        }
        public String incomelvl
        {
            get; set;
        }
        public String amount
        {
            get; set;
        }
        public String contactno
        {
            get; set;
        }
        public String emailid
        {
            get; set;
        }
        public String city
        {
            get; set;
        }
        public String experience
        {
            get; set;
        }
        public String currentprofession
        {
            get; set;
        }
        public string formtype
        {
            get; set;
        }
        public DateTime dateadded
        {
            get; set;
        }
        public int status
        {
            get; set;
        }
        public string formstatus
        {
            get; set;
        }
        public string dateofbirth
        {
            get; set;
        }
        public string dateofanniversry
        {
            get; set;
        }
        public string branchid
        {
            get; set;
        }
        public int compid
        {
            get; set;
        }
        public string remarks
        {
            get; set;
        }
        public string ext1
        {
            get; set;
        }
        public string ext2
        {
            get; set;
        }
        public string ext3
        {
            get; set;
        }
        public string ext4
        {
            get; set;
        }
    }
    public class SendMessage
    {
        public static void Send_Msg(String reciever, String message)
        {
            String strUrl = $"https://smsotp.in/index.php/smsapi/httpapi/?uname=solversolution&password=solversolution@45&sender=VOWELD&tempid=1607100000000250820&receiver={reciever}&route=TA&msgtype=1&sms={message}";

            WebRequest request = HttpWebRequest.Create(strUrl);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream s = (Stream)response.GetResponseStream();
            StreamReader readStream = new StreamReader(s);
            string dataString = readStream.ReadToEnd();
            response.Close();
            s.Close();
            readStream.Close();
        }
    }
}