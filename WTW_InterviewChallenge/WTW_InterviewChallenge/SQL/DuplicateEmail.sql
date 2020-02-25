/*
* Returns duplicate email addresses in Employee table.
*/
SELECT email from Employee GROUP BY email HAVING count(email)>1;