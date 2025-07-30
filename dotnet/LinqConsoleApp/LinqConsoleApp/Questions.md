## Questions

### Joins
* what is difference between Join and GroupJoin method
* 
* Determine which students are in which departments, and which teachers lead those departments
* Determine which students are in which classes, and which teachers teach those classes
* 

- [x] Join does 1:1 mapping, GroupJoin does 1:many mapping
	* There are multiple students in a department. 
	* Join will fetch a flat list of all the departments and students with duplicate departments
	* GroupJoin will fetch a list of departments with a list of students in each department
	* Output of Join is flat, output of GroupJoin is hierarchical. Result remains same.


### GroupBy