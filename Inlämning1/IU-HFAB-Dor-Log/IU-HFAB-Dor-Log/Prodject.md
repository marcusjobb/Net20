# ul-HFAB-Dor-log

## ASSIGMENT
https://classroom.google.com/u/0/c/MTU2NjQzMzM0Mjc0/m/MjA5MDUzOTI3NTM1/details



## DB
* Table:
    * Person
      * ID  (int AI)
      * First-name(text)
      * Last-name(text)
      * Tag (text) (unik)
      * apartmen -> Location (int)
      
    * Location			
      * ID  (int AI)
      * name(text)
      
    * Eventcode		
      * ID  (int AI)
      * Code(text)    
      
    * DoorName		
      * ID  (int AI)
      * Name (text)

    * Logg
      *  ID (int AI)
      * Date (date)
      * DoorID -> DoorName.ID (int)
      * EventcodeID -> Eventcode.ID (int)
      * PersonID --> Person.ID (int)
        
