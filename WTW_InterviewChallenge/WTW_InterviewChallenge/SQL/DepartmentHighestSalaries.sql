/*
* Returns employees with the highest salary per department. If multiple employees share the same highest salary, all are returned.
*/

SELECT d.name AS Department, e.name AS Employee, e.salary AS Salary
FROM Employee e 
LEFT JOIN Department d ON e.departmentId=d.departmentId
WHERE e.salary=(SELECT MAX(e2.salary) FROM Employee e2 WHERE e2.departmentId=d.departmentId)
ORDER BY d.departmentId
