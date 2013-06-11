create table TV_AVAILABLE_FUNCTIONALITY
(
    func_id raw(16) default sys_guid() primary key,
    func_tag varchar2(16) not null,
    is_Availeble number default 1 not null,
    func_value varchar2(50) 
);

create table TV_USERS_ROLES
(
    role_id number,
    role_name varchar2(25) not null,
    functionality_access clob,
    last_modif_date date default sysdate
    
);
alter table TV_USERS_ROLES add constraint TV_USERS_ROLES_PK PRIMARY KEY (role_id);


create table TV_USERS_DATA
(
    user_data_id number primary key,
    name varchar2(150),
    surname varchar2(150),
    lastname varchar2(150),
    last_modif_date date default sysdate
    
);

create table TV_USERS
(
    login varchar2(25),
    pass varchar2(25),
    date_start date,
    date_finish date,
    role_id number,
    user_data_id number,
    creation_date date,
    last_modif_date date
);

alter table TV_USERS add constraint TV_USERS_PK PRIMARY KEY (login, date_start);
alter table TV_USERS add constraint TV_USERS_CHECK_LOGIN CHECK (login is not null);
alter table TV_USERS add constraint TV_USERS_CHECK_PASS_1 CHECK (pass is not null);
alter table TV_USERS add constraint TV_USERS_CHECK_PASS_2 CHECK (length(pass) > 3);
alter table TV_USERS add constraint TV_USERS_FK_1 foreign key (role_id) REFERENCES TV_USERS_ROLES (role_id);
alter table TV_USERS add constraint TV_USERS_FK_2 foreign key (user_data_id) REFERENCES TV_USERS_DATA (user_data_id);

create or replace trigger TV_USERS_TBIU
before insert or update
on TV_USERS 
references new as new old as old
for each row
declare
    l_now date := sysdate;
begin
    if (:NEW.date_start is not null) then
        :NEW.date_start := trunc (:NEW.date_start);
    elsif(:NEW.date_finish is not null) then
       :NEW.date_finish := trunc (:NEW.date_start); 
    end if;
    :NEW.last_modif_date := l_now; 
    --
    if (inserting) then
        :NEW.creation_date := trunc(l_now);
    end if;
end;
/

create sequence TV_USERS_DATA_SEQ
MINVALUE 0
start with 0
increment by 1
maxvalue 99999999999999999
NOCYCLE
NOORDER;
/

create or replace trigger TV_USERS_DATA_TBIU
before insert or update
on TV_USERS_DATA
for each row
declare
    new_id number;
begin
    :new.last_modif_date := sysdate;
    if (inserting) then
        select TV_USERS_DATA_SEQ.NEXTVAL into new_id from dual;
        :new.user_data_id := new_id;
    end if;
end;

create sequence TV_USERS_ROLES_SEQ
MINVALUE 0
start with 0
increment by 1
maxvalue 99999999999999999
NOCYCLE
NOORDER;
/

create or replace trigger TV_USERS_ROLES_TBIU
before insert or update
on TV_USERS_ROLES
for each row
declare
    new_id number;
begin
    :new.last_modif_date := sysdate;
    if (inserting) then
        select TV_USERS_ROLES_SEQ.NEXTVAL into new_id from dual;
        :new.role_id := new_id;
    end if;
end;

create or replace function autorise_tv_user(p_login IN varchar2, p_passhash  IN varchar2)
return number
is
-- Авторизация пользователя
-- -1 - доступ запрещен
-- 0 - доступ разрешен
    l_operationRes number := -1;
    l_passHash varchar2(25);
    l_chk number;  
begin
    select count(*) into l_chk from TV_USERS where login = p_login and date_start <= trunc(sysdate) and date_finish >= trunc(sysdate);
    if (l_chk = 0) then
        return l_operationRes;
    else
        select pass into l_passHash from TV_USERS where login = p_login and date_start <= trunc(sysdate) and date_finish >= trunc(sysdate);
        if (l_passHash <> p_passhash) then
            return  l_operationRes;
        else 
            l_operationRes := 0;        
        end if;
    end if;
    return l_operationRes;
end;


