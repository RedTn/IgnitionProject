-- --------------------------------------------------
-- Own Script
-- --------------------------------------------------
-- Creating foreign key on [ApplicationId] in table 'AIAUsers'
ALTER TABLE [dbo].[AIAUsers]
ADD CONSTRAINT [FK_UserAspUser]
    FOREIGN KEY ([ApplicationUserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO