﻿declare
	CNT INTEGER:=0;
begin
	SELECT COUNT(*) INTO CNT
		FROM USER_CONSTRAINTS
			WHERE CONSTRAINT_NAME = UPPER('%CONSTRAINT_NAME%') and TABLE_NAME = UPPER('%TABLE_NAME%') and CONSTRAINT_TYPE = 'R';
	IF(CNT=0) THEN
		EXECUTE IMMEDIATE 'ALTER TABLE %TABLE_NAME%
						add CONSTRAINT %CONSTRAINT_NAME%
						FOREIGN KEY (%COLUMN_NAME%)
						REFERENCES %R_TABLE_NAME% (%R_COLUMN_NAME%))';
		DBMS_OUTPUT.PUT_LINE('Ограничение %CONSTRAINT_NAME% создано');
	else
		DBMS_OUTPUT.PUT_LINE('Ограничение %CONSTRAINT_NAME% уже существует');
	end if;
end;
/
SHOW ERRORS