# EdwardsDFSManagement
DFS Salary Information
My project is one that I plan to expand to assist in building NFL and NBA lineups for DraftKings and FanDuel. 
The idea is that you will have a JSON or CSV(Which will be a future implementation) that will read the player and salary to be able to filter through the salaries and soon to be added projections.
The goal of the project it to be able to manage large amounts of data easier to eliminate noise when researching positions.

To test the project you will run it and be given 6 choices. Each choice allows you to view or interact with the data. You can add a player with option 4 and view it in the list afterward with option 1.
To break the Master Loop just hit 0. Clicking any number outside of the list will provide invalid entry and restart. The lowest salary is 6000.

Features Used:
1. Master Loop with switches
2. Read Data from Json File
3. Used a Linq Quey (Search by name and search by Max Salary)
