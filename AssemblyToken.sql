USE [ThangLong]
GO

/****** Object:  SqlAssembly [TLU.Security]    Script Date: 11/1/2015 1:29:52 AM ******/
CREATE ASSEMBLY [TLU.Security]
FROM 0x4D5A90000300000004000000FFFF0000B800000000000000400000000000000000000000000000000000000000000000000000000000000000000000800000000E1FBA0E00B409CD21B8014CCD21546869732070726F6772616D2063616E6E6F742062652072756E20696E20444F53206D6F64652E0D0D0A2400000000000000504500004C010300D50735560000000000000000E00002210B010B00000E00000006000000000000AE2C00000020000000400000000000100020000000020000040000000000000006000000000000000080000000020000000000000300608500001000001000000000100000100000000000001000000000000000000000005C2C00004F000000004000007003000000000000000000000000000000000000006000000C000000242B00001C0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000200000080000000000000000000000082000004800000000000000000000002E74657874000000B40C000000200000000E000000020000000000000000000000000000200000602E7273726300000070030000004000000004000000100000000000000000000000000000400000402E72656C6F6300000C0000000060000000020000001400000000000000000000000000004000004200000000000000000000000000000000902C0000000000004800000002000500B021000074090000010000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000013300500AB0000000100001100731200000A0A067201000070281300000A13071207FE16170000016F1400000A0F00FE16020000016F1400000A2803000006281500000A6F1600000A26281700000A066F1400000A6F1800000A0B731900000A0C72190000700D08076F1A00000A130400110413081613092B27110811099113050009721B00007011058C1C000001281B00000A281C00000A0D00110917581309110911088E69FE04130A110A2DCB0913062B0011062A1E02281D00000A2A0013300200620000000200001100731E00000A0A731F00000A0B72190000700C2B36000720A08601006F2000000A0D0609280400000616FE01130511052D180006096F2100000A00081203282200000A281C00000A0C0000066F2300000A1EFE04130511052DBB0813042B0011042A00001330020019000000030000110002036F2400000A16FE010B072D04160A2B04170A2B00062A1E02281D00000A2A00000042534A4201000100000000000C00000076342E302E33303331390000000005006C00000000030000237E00006C0300001C04000023537472696E677300000000880700002C00000023555300B4070000100000002347554944000000C4070000B001000023426C6F620000000000000002000001471502080900000000FA253300160000010000001E000000030000000500000003000000240000000F0000000300000001000000010000000200000000000A00010000000000060056004F000A007E0069000600BC00A10006000301E90006002E011C01060045011C01060062011C01060081011C0106009A011C010600B3011C010600CE011C010600E9011C01060021020202060035020202060043021C0106005C021C0106008C0279024700A00200000600CF02AF020600EF02AF020A0028030D03060049033D03060057034F00060071034F0006008A033D030600C303A6030600D103A6030600EB034F0006009A004F00060000044F000000000001000000000001000100010010001B0029000500010001000100100036002900050001000300502000000000960088000A000100072100000000861894001000020010210000000096009A00140002008021000000009600C30018000200A52100000000861894001000040000000100D40000000100D70000000200E200210094002200290094002200310094002200390094002200410094002200490094002200510094002200590094002200610094002200690094002700710094002200790094002200810094002200890094002C00990094003200A10094001000A90094001000B10094001000B90060033C00090068034100C10078034500B1007F034D00C90093035300C9009D035800D10094001000D900DF035E00C10078036500C100F0036B000900940010000C0094001000E90094001000E900F7038B000C00FC039000F100680341000C00060496000C001004A80020008B0037002E003B0024012E001300FD002E001B000F012E0023000F012E002B0015012E003300FD002E000B00B3002E0043000F012E0053000F012E005B0045012E006B006F012E0073007C012E007B0085012E0083008E0171009A00AE00850004800000010000000000000000000000000029000000040000000000000000000000010046000000000004000000000000000000000001005D000000000000000000003C4D6F64756C653E00544C552E53656375726974792E646C6C0047656E6572617465546F6B656E00544C552E536563757269747900544C5552616E646F6D4E756D626572006D73636F726C69620053797374656D004F626A6563740053797374656D2E446174610053797374656D2E446174612E53716C54797065730053716C537472696E670052616E646F6D546F6B656E002E63746F720052616E646F6D0053797374656D2E436F6C6C656374696F6E732E47656E65726963004C697374603100436865636B45786974734E756D626572004964006C6973744E756D626572004E756D6265720053797374656D2E52756E74696D652E56657273696F6E696E67005461726765744672616D65776F726B4174747269627574650053797374656D2E5265666C656374696F6E00417373656D626C795469746C6541747472696275746500417373656D626C794465736372697074696F6E41747472696275746500417373656D626C79436F6E66696775726174696F6E41747472696275746500417373656D626C79436F6D70616E7941747472696275746500417373656D626C7950726F6475637441747472696275746500417373656D626C79436F7079726967687441747472696275746500417373656D626C7954726164656D61726B41747472696275746500417373656D626C7943756C747572654174747269627574650053797374656D2E52756E74696D652E496E7465726F70536572766963657300436F6D56697369626C65417474726962757465004775696441747472696275746500417373656D626C7956657273696F6E41747472696275746500417373656D626C7946696C6556657273696F6E4174747269627574650053797374656D2E446961676E6F73746963730044656275676761626C6541747472696275746500446562756767696E674D6F6465730053797374656D2E52756E74696D652E436F6D70696C6572536572766963657300436F6D70696C6174696F6E52656C61786174696F6E734174747269627574650052756E74696D65436F6D7061746962696C697479417474726962757465004D6963726F736F66742E53716C5365727665722E5365727665720053716C46756E6374696F6E4174747269627574650053797374656D2E5465787400537472696E674275696C646572004461746554696D65006765745F4E6F7700546F537472696E6700537472696E6700466F726D617400417070656E644C696E6500456E636F64696E67006765745F41534349490047657442797465730053797374656D2E53656375726974792E43727970746F677261706879005348413235364D616E616765640048617368416C676F726974686D00436F6D7075746548617368004279746500436F6E636174004E6578740041646400496E743332006765745F436F756E7400436F6E7461696E730000000000177B0030007D002D007B0031007D002D007B0032007D000101000D7B0030003A00780032007D0000000000CA23D7AC2E903E48BD0D7E696A001F430008B77A5C561934E0890500010E1109032000010300000E0900020215120D010808042001010E042001010205200101114904200101080401000000040000115D0320000E0700040E0E1C1C1C05200112590E04000012650520011D050E0620011D051D050500020E0E1C0500020E0E0E13070B12591D0512690E1D05050E115D1D0508020515120D01080420010808052001011300032000080D070615120D010812750E080E0205200102130004070202024901001A2E4E45544672616D65776F726B2C56657273696F6E3D76342E350100540E144672616D65776F726B446973706C61794E616D65122E4E4554204672616D65776F726B20342E351101000C544C552E536563757269747900000501000000000E0100094D6963726F736F667400002001001B436F7079726967687420C2A9204D6963726F736F6674203230313500002901002436623534303737612D666661372D346564312D393566632D32306630663739643165363300000C010007312E302E302E3000000801000701000000000801000800000000001E01000100540216577261704E6F6E457863657074696F6E5468726F77730100000000000000D507355600000000020000001C010000402B0000400D0000525344533E8E4F59620F02498D437A5E1B9FDCDF04000000653A5C57494E444F575320444154415C2E4E455420416476616E6365645C544C555C544C5553656375726974795C544C552E53656375726974795C6F626A5C44656275675C544C552E53656375726974792E70646200000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000842C000000000000000000009E2C0000002000000000000000000000000000000000000000000000902C0000000000000000000000005F436F72446C6C4D61696E006D73636F7265652E646C6C0000000000FF2500200010000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000100100000001800008000000000000000000000000000000100010000003000008000000000000000000000000000000100000000004800000058400000180300000000000000000000180334000000560053005F00560045005200530049004F004E005F0049004E0046004F0000000000BD04EFFE00000100000001000000000000000100000000003F000000000000000400000002000000000000000000000000000000440000000100560061007200460069006C00650049006E0066006F00000000002400040000005400720061006E0073006C006100740069006F006E00000000000000B00478020000010053007400720069006E006700460069006C00650049006E0066006F00000054020000010030003000300030003000340062003000000034000A00010043006F006D00700061006E0079004E0061006D006500000000004D006900630072006F0073006F0066007400000044000D000100460069006C0065004400650073006300720069007000740069006F006E000000000054004C0055002E005300650063007500720069007400790000000000300008000100460069006C006500560065007200730069006F006E000000000031002E0030002E0030002E003000000044001100010049006E007400650072006E0061006C004E0061006D006500000054004C0055002E00530065006300750072006900740079002E0064006C006C00000000005C001B0001004C006500670061006C0043006F007000790072006900670068007400000043006F0070007900720069006700680074002000A90020004D006900630072006F0073006F006600740020003200300031003500000000004C00110001004F0072006900670069006E0061006C00460069006C0065006E0061006D006500000054004C0055002E00530065006300750072006900740079002E0064006C006C00000000003C000D000100500072006F0064007500630074004E0061006D0065000000000054004C0055002E005300650063007500720069007400790000000000340008000100500072006F006400750063007400560065007200730069006F006E00000031002E0030002E0030002E003000000038000800010041007300730065006D0062006C0079002000560065007200730069006F006E00000031002E0030002E0030002E0030000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000C000000B03C00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
WITH PERMISSION_SET = SAFE

GO

