-- 1. Create db
-- 2.Create UserInfo Table
IF OBJECT_ID('UserInfo', 'U') IS NULL
BEGIN
CREATE TABLE UserInfo (
    EmailId VARCHAR(100) PRIMARY KEY,
    UserName VARCHAR(50) NOT NULL,
    Role VARCHAR(20) NOT NULL,
    Password VARCHAR(20) NOT NULL,

    CONSTRAINT CHK_UserName_Length CHECK (LEN(UserName) BETWEEN 1 AND 50),
    CONSTRAINT CHK_Role CHECK (Role IN ('Admin','Participant')),
    CONSTRAINT CHK_Password_Length CHECK (LEN(Password) BETWEEN 6 AND 20)
);
END

-- 3. Create EventDetails Table
IF OBJECT_ID('UserInfo', 'U') IS NULL
BEGIN
CREATE TABLE EventDetails (
    EventId INT PRIMARY KEY,
    EventName VARCHAR(50) NOT NULL,
    EventCategory VARCHAR(50) NOT NULL,
    EventDate DATETIME NOT NULL,
    Description VARCHAR(255),
    Status VARCHAR(20),

    CONSTRAINT CHK_Event_Status CHECK (Status IN ('Active','In-Active'))
);
END

-- 4. Create SpeakersDetails Table
IF OBJECT_ID('UserInfo', 'U') IS NULL
BEGIN
CREATE TABLE SpeakersDetails (
    SpeakerId INT PRIMARY KEY,
    SpeakerName VARCHAR(50) NOT NULL,

    CONSTRAINT CHK_SpeakerName_Length CHECK (LEN(SpeakerName) BETWEEN 1 AND 50)
);
END

-- 5. Create SessionInfo Table
IF OBJECT_ID('UserInfo', 'U') IS NULL
BEGIN
CREATE TABLE SessionInfo (
    SessionId INT PRIMARY KEY,
    EventId INT NOT NULL,
    SessionTitle VARCHAR(50) NOT NULL,
    SpeakerId INT NOT NULL,
    Description VARCHAR(255),
    SessionStart DATETIME NOT NULL,
    SessionEnd DATETIME NOT NULL,
    SessionUrl VARCHAR(255),

    CONSTRAINT FK_EventSession
    FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),

    CONSTRAINT FK_SpeakerSession
    FOREIGN KEY (SpeakerId) REFERENCES SpeakersDetails(SpeakerId)
);
END

-- 6. Create ParticipantEventDetails Table
IF OBJECT_ID('UserInfo', 'U') IS NULL
BEGIN
CREATE TABLE ParticipantEventDetails (
    Id INT PRIMARY KEY,
    ParticipantEmailId VARCHAR(100) NOT NULL,
    EventId INT NOT NULL,
    SessionId INT NOT NULL,
    IsAttended BIT,

    CONSTRAINT FK_ParticipantUser
    FOREIGN KEY (ParticipantEmailId) REFERENCES UserInfo(EmailId),

    CONSTRAINT FK_ParticipantEvent
    FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),

    CONSTRAINT FK_ParticipantSession
    FOREIGN KEY (SessionId) REFERENCES SessionInfo(SessionId)
);
END

