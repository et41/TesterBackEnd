IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250120053737_init'
)
BEGIN
    CREATE TABLE [Projects] (
        [Id] int NOT NULL IDENTITY,
        [ProjectId] nvarchar(max) NULL,
        [HvVoltage] nvarchar(max) NULL,
        [LvVoltage] nvarchar(max) NULL,
        [Taps] nvarchar(max) NULL,
        [RatedTap] nvarchar(max) NULL,
        [CustomerName] nvarchar(max) NULL,
        [VectorGroup] nvarchar(max) NULL,
        [Power] nvarchar(max) NULL,
        [DiffBetweenTaps] nvarchar(max) NULL,
        [LVTurns] nvarchar(max) NULL,
        [HVTurns] nvarchar(max) NULL,
        [TapTurns] nvarchar(max) NULL,
        [GuaranteedNoLoadLoss] nvarchar(max) NULL,
        [GuaranteedLoadLoss] nvarchar(max) NULL,
        [GuaranteedShortCircuitVoltage] nvarchar(max) NULL,
        CONSTRAINT [PK_Projects] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250120053737_init'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250120053737_init', N'9.0.1');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250120054715_init-2'
)
BEGIN
    DECLARE @var sysname;
    SELECT @var = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Projects]') AND [c].[name] = N'Taps');
    IF @var IS NOT NULL EXEC(N'ALTER TABLE [Projects] DROP CONSTRAINT [' + @var + '];');
    EXEC(N'UPDATE [Projects] SET [Taps] = 0 WHERE [Taps] IS NULL');
    ALTER TABLE [Projects] ALTER COLUMN [Taps] int NOT NULL;
    ALTER TABLE [Projects] ADD DEFAULT 0 FOR [Taps];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250120054715_init-2'
)
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Projects]') AND [c].[name] = N'TapTurns');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Projects] DROP CONSTRAINT [' + @var1 + '];');
    EXEC(N'UPDATE [Projects] SET [TapTurns] = 0 WHERE [TapTurns] IS NULL');
    ALTER TABLE [Projects] ALTER COLUMN [TapTurns] int NOT NULL;
    ALTER TABLE [Projects] ADD DEFAULT 0 FOR [TapTurns];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250120054715_init-2'
)
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Projects]') AND [c].[name] = N'RatedTap');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Projects] DROP CONSTRAINT [' + @var2 + '];');
    EXEC(N'UPDATE [Projects] SET [RatedTap] = 0 WHERE [RatedTap] IS NULL');
    ALTER TABLE [Projects] ALTER COLUMN [RatedTap] int NOT NULL;
    ALTER TABLE [Projects] ADD DEFAULT 0 FOR [RatedTap];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250120054715_init-2'
)
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Projects]') AND [c].[name] = N'ProjectId');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Projects] DROP CONSTRAINT [' + @var3 + '];');
    EXEC(N'UPDATE [Projects] SET [ProjectId] = 0 WHERE [ProjectId] IS NULL');
    ALTER TABLE [Projects] ALTER COLUMN [ProjectId] int NOT NULL;
    ALTER TABLE [Projects] ADD DEFAULT 0 FOR [ProjectId];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250120054715_init-2'
)
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Projects]') AND [c].[name] = N'Power');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Projects] DROP CONSTRAINT [' + @var4 + '];');
    EXEC(N'UPDATE [Projects] SET [Power] = 0 WHERE [Power] IS NULL');
    ALTER TABLE [Projects] ALTER COLUMN [Power] int NOT NULL;
    ALTER TABLE [Projects] ADD DEFAULT 0 FOR [Power];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250120054715_init-2'
)
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Projects]') AND [c].[name] = N'LvVoltage');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Projects] DROP CONSTRAINT [' + @var5 + '];');
    EXEC(N'UPDATE [Projects] SET [LvVoltage] = 0 WHERE [LvVoltage] IS NULL');
    ALTER TABLE [Projects] ALTER COLUMN [LvVoltage] int NOT NULL;
    ALTER TABLE [Projects] ADD DEFAULT 0 FOR [LvVoltage];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250120054715_init-2'
)
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Projects]') AND [c].[name] = N'LVTurns');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Projects] DROP CONSTRAINT [' + @var6 + '];');
    EXEC(N'UPDATE [Projects] SET [LVTurns] = 0 WHERE [LVTurns] IS NULL');
    ALTER TABLE [Projects] ALTER COLUMN [LVTurns] int NOT NULL;
    ALTER TABLE [Projects] ADD DEFAULT 0 FOR [LVTurns];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250120054715_init-2'
)
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Projects]') AND [c].[name] = N'HvVoltage');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Projects] DROP CONSTRAINT [' + @var7 + '];');
    EXEC(N'UPDATE [Projects] SET [HvVoltage] = 0 WHERE [HvVoltage] IS NULL');
    ALTER TABLE [Projects] ALTER COLUMN [HvVoltage] int NOT NULL;
    ALTER TABLE [Projects] ADD DEFAULT 0 FOR [HvVoltage];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250120054715_init-2'
)
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Projects]') AND [c].[name] = N'HVTurns');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Projects] DROP CONSTRAINT [' + @var8 + '];');
    EXEC(N'UPDATE [Projects] SET [HVTurns] = 0 WHERE [HVTurns] IS NULL');
    ALTER TABLE [Projects] ALTER COLUMN [HVTurns] int NOT NULL;
    ALTER TABLE [Projects] ADD DEFAULT 0 FOR [HVTurns];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250120054715_init-2'
)
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Projects]') AND [c].[name] = N'GuaranteedShortCircuitVoltage');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Projects] DROP CONSTRAINT [' + @var9 + '];');
    EXEC(N'UPDATE [Projects] SET [GuaranteedShortCircuitVoltage] = CAST(0 AS real) WHERE [GuaranteedShortCircuitVoltage] IS NULL');
    ALTER TABLE [Projects] ALTER COLUMN [GuaranteedShortCircuitVoltage] real NOT NULL;
    ALTER TABLE [Projects] ADD DEFAULT CAST(0 AS real) FOR [GuaranteedShortCircuitVoltage];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250120054715_init-2'
)
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Projects]') AND [c].[name] = N'GuaranteedNoLoadLoss');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [Projects] DROP CONSTRAINT [' + @var10 + '];');
    EXEC(N'UPDATE [Projects] SET [GuaranteedNoLoadLoss] = CAST(0 AS real) WHERE [GuaranteedNoLoadLoss] IS NULL');
    ALTER TABLE [Projects] ALTER COLUMN [GuaranteedNoLoadLoss] real NOT NULL;
    ALTER TABLE [Projects] ADD DEFAULT CAST(0 AS real) FOR [GuaranteedNoLoadLoss];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250120054715_init-2'
)
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Projects]') AND [c].[name] = N'GuaranteedLoadLoss');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [Projects] DROP CONSTRAINT [' + @var11 + '];');
    EXEC(N'UPDATE [Projects] SET [GuaranteedLoadLoss] = CAST(0 AS real) WHERE [GuaranteedLoadLoss] IS NULL');
    ALTER TABLE [Projects] ALTER COLUMN [GuaranteedLoadLoss] real NOT NULL;
    ALTER TABLE [Projects] ADD DEFAULT CAST(0 AS real) FOR [GuaranteedLoadLoss];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250120054715_init-2'
)
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Projects]') AND [c].[name] = N'DiffBetweenTaps');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [Projects] DROP CONSTRAINT [' + @var12 + '];');
    EXEC(N'UPDATE [Projects] SET [DiffBetweenTaps] = CAST(0 AS real) WHERE [DiffBetweenTaps] IS NULL');
    ALTER TABLE [Projects] ALTER COLUMN [DiffBetweenTaps] real NOT NULL;
    ALTER TABLE [Projects] ADD DEFAULT CAST(0 AS real) FOR [DiffBetweenTaps];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250120054715_init-2'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250120054715_init-2', N'9.0.1');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250120061417_init-3'
)
BEGIN
    ALTER TABLE [Projects] DROP CONSTRAINT [PK_Projects];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250120061417_init-3'
)
BEGIN
    EXEC sp_rename N'[Projects]', N'Project', 'OBJECT';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250120061417_init-3'
)
BEGIN
    ALTER TABLE [Project] ADD CONSTRAINT [PK_Project] PRIMARY KEY ([Id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250120061417_init-3'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250120061417_init-3', N'9.0.1');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250122122829_mssql.local_migration_530'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250122122829_mssql.local_migration_530', N'9.0.1');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250122124710_mssql.local_migration_764'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250122124710_mssql.local_migration_764', N'9.0.1');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250123102959_mssql.local_migration_167'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250123102959_mssql.local_migration_167', N'9.0.1');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250128120344_aa'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250128120344_aa', N'9.0.1');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250130101635_v2'
)
BEGIN
    DECLARE @var13 sysname;
    SELECT @var13 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Project]') AND [c].[name] = N'LvVoltage');
    IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [Project] DROP CONSTRAINT [' + @var13 + '];');
    ALTER TABLE [Project] ALTER COLUMN [LvVoltage] float NOT NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250130101635_v2'
)
BEGIN
    DECLARE @var14 sysname;
    SELECT @var14 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Project]') AND [c].[name] = N'HvVoltage');
    IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [Project] DROP CONSTRAINT [' + @var14 + '];');
    ALTER TABLE [Project] ALTER COLUMN [HvVoltage] float NOT NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250130101635_v2'
)
BEGIN
    DECLARE @var15 sysname;
    SELECT @var15 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Project]') AND [c].[name] = N'GuaranteedShortCircuitVoltage');
    IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [Project] DROP CONSTRAINT [' + @var15 + '];');
    ALTER TABLE [Project] ALTER COLUMN [GuaranteedShortCircuitVoltage] float NOT NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250130101635_v2'
)
BEGIN
    DECLARE @var16 sysname;
    SELECT @var16 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Project]') AND [c].[name] = N'GuaranteedNoLoadLoss');
    IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [Project] DROP CONSTRAINT [' + @var16 + '];');
    ALTER TABLE [Project] ALTER COLUMN [GuaranteedNoLoadLoss] int NOT NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250130101635_v2'
)
BEGIN
    DECLARE @var17 sysname;
    SELECT @var17 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Project]') AND [c].[name] = N'GuaranteedLoadLoss');
    IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [Project] DROP CONSTRAINT [' + @var17 + '];');
    ALTER TABLE [Project] ALTER COLUMN [GuaranteedLoadLoss] int NOT NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250130101635_v2'
)
BEGIN
    DECLARE @var18 sysname;
    SELECT @var18 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Project]') AND [c].[name] = N'DiffBetweenTaps');
    IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [Project] DROP CONSTRAINT [' + @var18 + '];');
    ALTER TABLE [Project] ALTER COLUMN [DiffBetweenTaps] float NOT NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250130101635_v2'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250130101635_v2', N'9.0.1');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250130101929_mssql.local_migration_468'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250130101929_mssql.local_migration_468', N'9.0.1');
END;

COMMIT;
GO

