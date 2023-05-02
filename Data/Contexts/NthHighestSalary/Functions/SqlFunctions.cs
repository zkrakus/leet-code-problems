namespace Data.Contexts.NthHighestSalary.Functions;
public static class SqlFunctions
{
    public const string GetNthHighestEmployee =
        @"EXEC('
            CREATE OR ALTER FUNCTION usp_GetNthHighestSalary(@N INT) RETURNS INT AS
            BEGIN
                RETURN (
                    SELECT Max([Salary]) as NthHighestSalary
			            FROM dbo.Employees as a 
			            Where a.Salary
			            NOT IN (
				            SELECT DISTINCT TOP(@N - 1)
					            Salary
				            FROM [Employees]
				            Order By [Salary] DESC 
			            )
                );
            END
        ');";

    public const string DeleteGetNthHighestEmployee =
        @"EXEC('
            DROP FUNCTION FUNCTION usp_GetNthHighestSalary;
        ');";

    public const string GetNthHighestEmployeeDenseRankWithTempTable =
        @"EXEC('
            CREATE OR ALTER FUNCTION usp_GetNthHighestSalary(@N INT) RETURNS INT AS
            BEGIN
                RETURN (
                    If OBJECT_ID('tmpdb..##tempEmployees') IS NOT NULL
	                    DROP TABLE #tempEmployees

                    Select distinct Max(a.Salary) as [SALARY]
                    INTO #tempEmployees
                    FROM (
	                    Select a.Salary, 
                        DENSE_RANK() over (ORDER BY Salary DESC) as [Rank]
	                    From NthHighestSalary.dbo.Employees AS a
                    ) as a
                    WHERE a.[Rank] = @N

                    Declare @Salary INT
                    Select @Salary = Salary from #tempEmployees
                    SELECT CASE 
	                    WHEN NOT EXISTS (SELECT TOP(1) * FROM #tempEmployees) THEN NULL
	                    ELSE @Salary
	                    END as Salary

                    DROP TABLE #tempEmployees
                );
            END
        ')";

    public const string GetNthHighestEmployeeDenseRank =
        @"EXEC('
                CREATE OR ALTER FUNCTION usp_GetNthHighestSalary(@N INT) RETURNS INT AS
                BEGIN
                    RETURN (
                        Declare @Salary INT
                        Select distinct @Salary = Max(a.Salary)
                        FROM (
	                        Select a.Salary , DENSE_RANK() over (ORDER BY Salary DESC) as [Rank]
	                        From NthHighestSalary.dbo.Employees AS a
                        ) as a
                        WHERE a.[Rank] = @N

                        SELECT CASE WHEN @@Rowcount = 0 
	                        THEN NULL
	                        ELSE @Salary
	                        END as Salary
                    );
                END
            ')";
}
