using CHUACSystem.Data.Models;
using System;
using System.Collections.Generic;

namespace CHUACSystem.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ACSystemDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var dt = DateTime.Now;
            var electricMeters = new List<PowerMeter>
            {
                new PowerMeter{ Name="現在耗電量(KW)",Value=26,AddedOn=dt},
                new PowerMeter{ Name="有效功率(KVA)",Value=34,AddedOn=dt},
                new PowerMeter{ Name="頻率(HZ)",Value=60,AddedOn=dt},
                new PowerMeter{ Name="三相電壓(V)",Value=390,AddedOn=dt},
                new PowerMeter{ Name="三相電流(A)",Value=52,AddedOn=dt},
                new PowerMeter{ Name="瓦時計(KWH)",Value=2138731,AddedOn=dt},
            };
            context.PowerMeter.AddRange(electricMeters);
            context.SaveChanges();

            // 時序排程
            var hostGroups = new List<HostGroup>
            {
                new HostGroup {
                    Name = "冰水",
                    AddedOn =dt,
                    Hosts = new List<Host>
                    {
                        new Host
                        {
                            Name ="冰水主機(一)",
                            HeaderName = "(一)號主機",
                            Enable = true,
                            Week0= false,
                            Week1 = true,
                            Week2 = true,
                            Week3 = true,
                            Week4 = true,
                            Week5 = true,
                            Week6 = false,
                            AddedOn =dt,
                        },
                        new Host
                        {
                            Name ="冰水主機(二)",
                            HeaderName = "(二)號主機",
                            Enable = false,
                            Week0= false,
                            Week1 = false,
                            Week2 = false,
                            Week3 = false,
                            Week4 = false,
                            Week5 = false,
                            Week6 = false,
                            AddedOn =dt,
                        }
                    },
                    HostSchedules = new List<HostSchedule>
                    {
                        new HostSchedule
                        {
                            Name = "空調啟動排程(一)",
                            Week0 = "08201100",
                            Week1 = "07501100",
                            Week2 = "07501100",
                            Week3 = "07501100",
                            Week4 = "07501100",
                            Week5 = "07501100",
                            Week6 = "08151100",
                            AddedOn =dt,
                        },
                        new HostSchedule
                        {
                            Name = "空調啟動排程(二)",
                            Week0 = "00000000",
                            Week1 = "17302145",
                            Week2 = "17302145",
                            Week3 = "17302145",
                            Week4 = "17302130",
                            Week5 = "16302130",
                            Week6 = "00000000",
                            AddedOn =dt,
                        },
                        new HostSchedule
                        {
                            Name = "空調啟動排程(三)",
                            Week0 = "00000000",
                            Week1 = "00000000",
                            Week2 = "00000000",
                            Week3 = "00000000",
                            Week4 = "00000000",
                            Week5 = "00000000",
                            Week6 = "00000000",
                            AddedOn =dt,
                        }
                    }
                },
                new HostGroup {
                    Name = "溶冰",
                    AddedOn =dt,
                    Hosts = new List<Host>
                    {
                        new Host
                        {
                            Name ="溶冰主機",
                            Enable = true,
                            Week0= true,
                            Week1 = true,
                            Week2 = true,
                            Week3 = true,
                            Week4 = true,
                            Week5 = true,
                            Week6 = true,
                            AddedOn =dt,
                        }
                    },
                    HostSchedules = new List<HostSchedule>
                    {
                        new HostSchedule
                        {
                            Name = "溶冰啟動排程(一)",
                            Week0 = "08201255",
                            Week1 = "11001215",
                            Week2 = "11001215",
                            Week3 = "11001215",
                            Week4 = "11001215",
                            Week5 = "11002130",
                            Week6 = "08201255",
                            AddedOn =dt,
                        },
                        new HostSchedule
                        {
                            Name = "溶冰啟動排程(二)",
                            Week0 = "12552120",
                            Week1 = "12302155",
                            Week2 = "12302155",
                            Week3 = "12302130",
                            Week4 = "12302130",
                            Week5 = "12202130",
                            Week6 = "12552120",
                            AddedOn =dt,
                        },
                    }
                },
                new HostGroup
                {
                    Name = "儲冰",
                    AddedOn =dt,
                    Hosts = new List<Host>
                    {
                        new Host
                        {
                            Name ="儲冰(一)號機",
                            HeaderName = "(一)號主機",
                            Enable = true,
                            Week0= true,
                            Week1 = true,
                            Week2 = true,
                            Week3 = true,
                            Week4 = true,
                            Week5 = true,
                            Week6 = true,
                            AddedOn =dt,
                        },
                        new Host
                        {
                            Name ="儲冰(二)號機",
                            HeaderName = "(二)號主機",
                            Enable = true,
                            Week0= true,
                            Week1 = true,
                            Week2 = true,
                            Week3 = true,
                            Week4 = true,
                            Week5 = true,
                            Week6 = true,
                            AddedOn =dt,
                        }
                    },
                     HostSchedules = new List<HostSchedule>
                    {
                        new HostSchedule
                        {
                            Name = "儲冰啟動排程(一)",
                            Week0 = "22300730",
                            Week1 = "22300730",
                            Week2 = "22300730",
                            Week3 = "22300730",
                            Week4 = "22300730",
                            Week5 = "22300730",
                            Week6 = "22300730",
                            AddedOn =dt,
                        }
                    }
                }
            };
            context.HostGroup.AddRange(hostGroups);
            context.SaveChanges();
            // 溫度啟停設定
            var equipTempSettings = new List<EquipTempSetting>
            {
                new EquipTempSetting { Name="冰水系統.參考外氣T0",Start=15,End=16,AddedOn=dt},
                new EquipTempSetting { Name="送風系統.參考外氣T0",Start=13,End=14,AddedOn=dt},
                new EquipTempSetting { Name="溶冰量不足主機啟動.參考T13",Start=8,End=9,AddedOn=dt},
                new EquipTempSetting { Name="1號主機啟動溫度.參考T16",Start=8.5F,End=10,AddedOn=dt},
                new EquipTempSetting { Name="2號主機啟動溫度.參考T16",Start=8.5F,End=10,AddedOn=dt},
            };
            context.EquipTempSetting.AddRange(equipTempSettings);
            context.SaveChanges();
            //水流開關強制導通
            var flowStatuses = new List<FlowStatus>
            {
                new FlowStatus { SeqNo="F1",Name ="冰水泵浦(一)", Enable=true,AddedOn=dt},
                new FlowStatus { SeqNo="F2",Name ="冰水泵浦(二)", Enable=true,AddedOn=dt},
                new FlowStatus { SeqNo="F3",Name ="溶冰泵浦",AddedOn=dt},
                new FlowStatus { SeqNo="F4",Name ="滷水泵浦",AddedOn=dt},
                new FlowStatus { SeqNo="F5",Name ="儲冰泵浦(一)",AddedOn=dt},
                new FlowStatus { SeqNo="F6",Name ="儲冰泵浦(二)",AddedOn=dt},
                new FlowStatus { SeqNo="F7",Name ="冷卻水泵浦(一)",AddedOn=dt},
                new FlowStatus { SeqNo="F8",Name ="冷卻水泵浦(二)",AddedOn=dt},
                new FlowStatus { SeqNo="F9",Name ="管理一館區域泵浦",AddedOn=dt},
                new FlowStatus { SeqNo="F10",Name ="建築一館區域泵浦",AddedOn=dt}
            };
            context.FlowStatus.AddRange(flowStatuses);
            context.SaveChanges();
            //備用泵浦取代
            var equipConns = new List<EquipConn>
            {
                new EquipConn{Name="區域泵浦SP取代區域1",AddedOn=dt},
                new EquipConn{Name="區域泵浦SP取代區域2",AddedOn=dt},
                new EquipConn{Name="冰水泵浦SP取代冰水1",AddedOn=dt},
                new EquipConn{Name="冰水泵浦SP取代冰水2",AddedOn=dt},
                new EquipConn{Name="冷卻泵浦SP取代冷卻1",AddedOn=dt},
                new EquipConn{Name="冷卻泵浦SP取代冷卻2",Enable=true,AddedOn=dt},
                new EquipConn{Name="儲冰泵浦SP取代儲冰1",AddedOn=dt},
                new EquipConn{Name="儲冰泵浦SP取代儲冰2",AddedOn=dt},
                new EquipConn{Name="冰水泵(二)取代冰水泵(一)",Enable=true,AddedOn=dt},
                new EquipConn{Name="滷水泵(二)取代滷水泵(一)",AddedOn=dt},
            };
            context.EquipConn.AddRange(equipConns);
            context.SaveChanges();
            //溫度偏差設定
            var tempSettings = new List<TempSetting>
            {
                new TempSetting{SeqNo="t0",Sequence=0,Name="外氣溫度",AddedOn=dt},
                new TempSetting{SeqNo="t1",Sequence=1,Name="冰水主機(一)出口溫度",AddedOn=dt},
                new TempSetting{SeqNo="t2",Sequence=2,Name="冰水主機(二)出口溫度",AddedOn=dt},
                new TempSetting{SeqNo="t3",Sequence=3,Name="冷熱交換器冰水出口溫度",AddedOn=dt},
                new TempSetting{SeqNo="t4",Sequence=4,Name="冷熱交換器滷水出口溫度",AddedOn=dt},
                new TempSetting{SeqNo="t5",Sequence=5,Name="滷水(一)出口溫度",AddedOn=dt},
                new TempSetting{SeqNo="t6",Sequence=6,Name="滷水(二)出口溫度",AddedOn=dt},
                new TempSetting{SeqNo="t7",Sequence=7,Name="主機(一)冷卻水出口溫度",AddedOn=dt},
                new TempSetting{SeqNo="t8",Sequence=8,Name="主機(二)冷卻水出口溫度",AddedOn=dt},
                new TempSetting{SeqNo="t9",Sequence=9,Name="區域泵回流端(二) 綜合",AddedOn=dt},
                new TempSetting{SeqNo="t10",Sequence=10,Name="區域泵回流端(一) 建築",AddedOn=dt},
                new TempSetting{SeqNo="t11",Sequence=11,Name="主機(一)(二)冷卻水出口溫度",AddedOn=dt},
                new TempSetting{SeqNo="t12",Sequence=12,Name="入儲冰桶溫度",AddedOn=dt},
                new TempSetting{SeqNo="t13",Sequence=13,Name="出儲冰桶溫度",AddedOn=dt},
                new TempSetting{SeqNo="t14",Sequence=14,Name="區域水泵回水及水管溫度",AddedOn=dt},
                new TempSetting{SeqNo="t15",Sequence=15,Name="冰水泵回水及水管溫度",AddedOn=dt},
                new TempSetting{SeqNo="t16",Sequence=16,Name="區域水泵回水及水管溫度",AddedOn=dt},
                new TempSetting{SeqNo="t17",Sequence=17,Name="冰水泵回水及水管溫度",AddedOn=dt}
            };
            context.TempSetting.AddRange(tempSettings);
            context.SaveChanges();
            //儲冰桶設定
            var outTempSettings = new List<OutTempSetting>
            {
                new OutTempSetting {Name="儲冰桶攪拌馬達",Start=40,End=0,AddedOn=dt},
                new OutTempSetting {Name="儲冰量停止設定",Start=105,AddedOn=dt}
            };
            context.OutTempSetting.AddRange(outTempSettings);
            context.SaveChanges();
            //區域泵浦延遲停止時間
            var pumpDelayTime = new OtherSetting
            {
                Name = "區域泵浦延遲停止時間",
                Value = "300",
                AddedOn = dt,
            };
            context.OtherSetting.Add(pumpDelayTime);
            context.SaveChanges();
            //教室
            var classroomGroups = new List<ClassroomGroup>
            {
                // 0. MBF
                new ClassroomGroup
                {
                    Name = "MBF",
                    Seq=0,
                    Image="b1f_manage_4.png",
                    AddedOn = dt,
                    Classrooms = new List<Classroom>
                    {
                        new Classroom {Name="MB02",Seq=0,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="MB03",Seq=1,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="MB04",Seq=2,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="MB05",Seq=3,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="MB06",Seq=4,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="MB07",Seq=5,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="MB08",Seq=6,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="MB09",Seq=7,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="MB10",Seq=8,IsAcOn=false,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="MB11",Seq=9,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="MB12",Seq=10,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="MB13AB",Seq=11,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="MB14A",Seq=12,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="MB15",Seq=13,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="MB16",Seq=14,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="MB19_前",Seq=15,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="MB19_後",Seq=16,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="MB20_前",Seq=17,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="MB20_後",Seq=18,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="MB21",Seq=19,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="MB22",Seq=20,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="MB23/MB23A",Seq=21,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="MB24/MB24A",Seq=22,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="MB25",Seq=23,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="MB26",Seq=24,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="MB27",Seq=25,AddedOn=dt,ModifiedOn=dt},
                    }
                },
                // 1. M1F
                new ClassroomGroup
                {
                    Name = "M1F",
                    Image="1f_manage_4.png",
                    AddedOn = dt,
                    Seq=1,
                    Classrooms = new List<Classroom>
                    {
                        new Classroom { Name="M101",Seq=0,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom { Name="M103",Seq=1,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom { Name="M104",Seq=2,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom { Name="M105",Seq=3,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom { Name="M106",Seq=4,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom { Name="M107",Seq=5,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom { Name="M108",Seq=6,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom { Name="M109",Seq=7,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom { Name="M110",Seq=8,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom { Name="M111",Seq=9,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom { Name="M112",Seq=10,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom { Name="M113",Seq=11,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom { Name="M114",Seq=12,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom { Name="M116",Seq=13,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom { Name="M117",Seq=14,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom { Name="M118",Seq=15,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom { Name="M119",Seq=16,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom { Name="M121",Seq=17,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom { Name="M120/M122",Seq=18,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom { Name="M123(後)",Seq=19,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom { Name="M123",Seq=20,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom { Name="M126",Seq=21,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom { Name="M127",Seq=22,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom { Name="M128",Seq=23,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom { Name="M129",Seq=24,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom { Name="M130",Seq=25,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom { Name="M131",Seq=26,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom { Name="M132",Seq=27,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom { Name="M133",Seq=28,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom { Name="M134",Seq=29,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom { Name="M135",Seq=30,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom { Name="M136",Seq=31,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom { Name="M137ABC",Seq=32,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                    }
                },
                // 2. M2F
                new ClassroomGroup
                {
                    Name = "M2F",
                    Image="2f_manage_4.png",
                    AddedOn = dt,
                    Seq=2,
                    Classrooms = new List<Classroom>
                    {
                        new Classroom {Name="M201",Seq=0,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="M202",Seq=1,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="M203",Seq=2,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="M204",Seq=3,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="M205",Seq=4,IsAcOn=false,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="M206",Seq=5,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="M207",Seq=6,IsAcOn=false,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="M208",Seq=7,IsAcOn=false,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="M209",Seq=8,IsAcOn=false,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="M210",Seq=9,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="M211AB",Seq=10,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="M212A/M212B",Seq=11,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="M213",Seq=12,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="M214",Seq=13,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="M215",Seq=14,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="M216A/M216B",Seq=15,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                    }
                },
                // 3. M3F
                new ClassroomGroup
                {
                    Name="M3F",
                    Image="3f_manage_4.png",
                    Seq=3,
                    AddedOn = dt,
                    Classrooms = new List<Classroom>
                    {
                        new Classroom{Name="M301",Seq=0,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M302",Seq=1,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M303",Seq=2,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M304",Seq=3,IsAcOn=false,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M305",Seq=4,IsAcOn=false,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M306",Seq=5,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M307",Seq=6,IsAcOn=false,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M308",Seq=7,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M309",Seq=8,IsAcOn=false,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M310",Seq=9,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M311AB",Seq=10,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M312ABCD",Seq=11,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M313ABC",Seq=12,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M314",Seq=13,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M315",Seq=14,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M316",Seq=15,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M317",Seq=16,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                    }
                },
                // 4. M4F
                new ClassroomGroup
                {
                    Name = "M4F",
                    Image="4f_manage_4.png",
                    Seq=4,
                    AddedOn = dt,
                    Classrooms = new List<Classroom>
                    {
                        new Classroom{Name="M401",Seq=0,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M402",Seq=1,IsAcOn=false,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M403",Seq=2,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M404",Seq=3,IsAcOn=false,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M405",Seq=4,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M406",Seq=5,IsAcOn=false,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M407A/M407B",Seq=6,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M407BC",Seq=7,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M408A/M408B",Seq=8,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M408BC",Seq=9,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M411(前)",Seq=10,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M411(後)",Seq=11,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M412",Seq=12,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M414",Seq=12,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M415",Seq=12,IsAcOn=false,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M416",Seq=12,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M417",Seq=12,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                    }
                },
                // 5. M5F
                new ClassroomGroup
                {
                    Name = "M5F",
                    Image="5f_manage_4.png",
                    Seq=5,
                    AddedOn = dt,
                    Classrooms = new List<Classroom>
                    {
                        new Classroom{Name="M501",Seq=0,IsAcOn=false,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M502",Seq=1,IsAcOn=false,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M503",Seq=2,IsAcOn=false,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M504",Seq=3,IsAcOn=false,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M505/M507/M509/M511",Seq=4,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M506/M508/M510/M512",Seq=5,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M513",Seq=6,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M514/M516/M518/M520",Seq=6,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M515/M515A",Seq=7,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M517",Seq=8,IsAcOn=false,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M519",Seq=9,IsAcOn=false,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M521",Seq=10,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M522/M524/M526/M528",Seq=11,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M525",Seq=12,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M527",Seq=13,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M530/M532/M530A",Seq=14,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                    }
                },
                // 6. M6F
                new ClassroomGroup
                {
                    Name = "M6F",
                    Image="6f_manage_4.png",
                    Seq=6,
                    AddedOn = dt,
                    Classrooms = new List<Classroom>
                    {
                        new Classroom{Name="M601",Seq=0,IsAcOn=false,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M602",Seq=1,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M603",Seq=2,IsAcOn=false,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M604",Seq=3,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M605",Seq=4,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M606",Seq=5,IsAcOn=false,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M607",Seq=6,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M608",Seq=7,IsAcOn=false,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M609",Seq=8,IsAcOn=false,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M610",Seq=9,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M611",Seq=10,IsAcOn=false,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M612/M612A/M614",Seq=11,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M613",Seq=12,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M615/M616/M617/M617A/M618",Seq=13,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="M619/M620/M620A",Seq=14,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                    }
                },
                // 7. A1F
                new ClassroomGroup
                {
                    Name="A1F",
                    Seq = 7,
                    Image="1f_build_2.png",
                    Classrooms = new List<Classroom>
                    {
                        new Classroom {Name="A101(敦煌書局)",Seq=0,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="A102",Seq=1,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom {Name="A103階梯教室(一)",Seq=2,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                    }
                },
                // 8. A2F
                new ClassroomGroup
                {
                    Name="A2F",
                    Image= "2f_build_4.png",
                    Seq=8,
                    AddedOn = dt,
                    Classrooms = new List<Classroom>
                    {
                        new Classroom{Name="A201A203",Seq=0,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A202",Seq=1,IsAcOn=false,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A204A206A208",Seq=2,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A205A207",Seq=3,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A209A211",Seq=4,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A210A212",Seq=5,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A213",Seq=6,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A215",Seq=7,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A216",Seq=8,IsAcOn=false,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A217",Seq=9,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A219",Seq=10,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A218",Seq=11,IsAcOn=false,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A220",Seq=12,IsAcOn=false,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A221",Seq=13,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A222演講廳",Seq=14,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A223",Seq=15,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A224階梯教室(一)",Seq=16,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A229",Seq=17,IsAcOn=false,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A233",Seq=18,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                    }
                },
                // 9. A3F
                new ClassroomGroup
                {
                    Name ="A3F",
                    Image="3f_build_5.png",
                    Seq = 9,
                    AddedOn = dt,
                    Classrooms = new List<Classroom>
                    {
                        new Classroom{Name="A307",Seq=0,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A308",Seq=1,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A309",Seq=2,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A310A310B",Seq=3,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A311",Seq=4,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A314",Seq=5,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A316",Seq=6,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A317",Seq=7,IsAcOn=false,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A318",Seq=8,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A319",Seq=9,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A320",Seq=10,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A324",Seq=11,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                    }
                },
                // 10. A4F
                new ClassroomGroup
                {
                    Name ="A4F",
                    Image ="4f_build_5.png",
                    Seq = 10,
                    AddedOn = dt,
                    Classrooms = new List<Classroom>
                    {
                        new Classroom{Name="A401",Seq=0,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A402",Seq=1,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A403",Seq=2,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A404",Seq=3,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A405",Seq=4,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A406",Seq=5,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A407",Seq=6,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A408",Seq=7,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A409A409_123",Seq=8,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A414",Seq=9,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A416",Seq=10,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A418",Seq=11,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A420",Seq=12,IsAcOn=false,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A421",Seq=13,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A423AB",Seq=14,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A424AB",Seq=15,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A425",Seq=16,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A426A428",Seq=17,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A430",Seq=18,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                    }
                },
                // 11. A5F
                new ClassroomGroup
                {
                    Name="A5F",
                    Image ="5f_build_7.png",
                    Seq=11,
                    AddedOn=dt,
                    Classrooms =new List<Classroom>
                    {
                        new Classroom{Name="A501A",Seq=0,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A501B",Seq=1,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A501C",Seq=2,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A501D",Seq=3,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A505",Seq=4,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A507",Seq=5,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A508AB",Seq=6,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A510",Seq=7,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A511",Seq=8,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A512",Seq=9,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A513",Seq=10,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A514",Seq=11,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A515",Seq=12,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A516",Seq=13,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A517",Seq=14,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A518",Seq=15,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A519",Seq=16,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A520",Seq=17,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                        new Classroom{Name="A522",Seq=19,IsAcOn=true,IsAuto=true,AddedOn=dt,ModifiedOn=dt},
                    }
                },
            };
            context.ClassroomGroup.AddRange(classroomGroups);
            context.SaveChanges();
            //溫度歷史資料
            var dtLength = 12;
            var dtMinuteRange = 15;
            var currentDt = dt.AddMinutes(-5);
            var pastTimeList = new DateTime[dtLength];
            for (int i = 0; i < dtLength; i++)
            {
                pastTimeList[(dtLength - 1) - i] = currentDt;
                currentDt = currentDt.AddMinutes(-dtMinuteRange);
            }
            var TemperatureHistories = new List<TemperatureHistory>();
            var random = new Random();
            for (int j = 0; j <= 17; j++)
            {
                for (int t = 0; t < pastTimeList.Length; t++)
                {
                    TemperatureHistories.Add(new TemperatureHistory
                    {
                        Name = $"t{j.ToString()}",
                        Value = random.Next(20, 40),
                        AddedOn = pastTimeList[t]
                    });
                }
            }
            context.TemperatureHistory.AddRange(TemperatureHistories);
            context.SaveChanges();
            //設備清單
            var equipmentGroups = new List<EquipmentGroup>
            {
                new EquipmentGroup
                {
                    Name="equipment_status",
                    Seq = 0,
                    AddedOn = dt,
                    Equipments = new List<Equipment>
                    {
                        new Equipment{ Name = "溶冰啟動訊號",Seq = 0, Value = 1, AddedOn = dt, ModifiedOn = dt },
                        new Equipment{ Name = "主機啟動(一)號機",Seq = 1, Value = 0, AddedOn = dt, ModifiedOn = dt },
                        new Equipment{ Name = "主機啟動(二)號機",Seq = 2, Value = 0, AddedOn = dt, ModifiedOn = dt },
                        new Equipment{ Name = "儲冰啟動(一)號機",Seq = 3, Value = 0, AddedOn = dt, ModifiedOn = dt },
                        new Equipment{ Name = "儲冰啟動(二)號機",Seq = 4, Value = 0, AddedOn = dt, ModifiedOn = dt },
                        new Equipment{ Name = "區域泵浦(一)",Seq = 5, Value = 1, AddedOn = dt, ModifiedOn = dt },
                        new Equipment{ Name = "區域泵浦SP",Seq = 6, Value = 0, AddedOn = dt, ModifiedOn = dt },
                        new Equipment{ Name = "區域泵浦(二)",Seq = 7, Value = 1, AddedOn = dt, ModifiedOn = dt },
                        new Equipment{ Name = "溶冰泵浦(一)",Seq = 8, Value = 1, AddedOn = dt, ModifiedOn = dt },
                        new Equipment{ Name = "溶冰泵浦(二)",Seq = 9, Value = 1, AddedOn = dt, ModifiedOn = dt },
                        new Equipment{ Name = "滷水泵浦(一)",Seq = 10, Value = 1, AddedOn = dt, ModifiedOn = dt },
                        new Equipment{ Name = "滷水泵浦(二)",Seq = 11, Value = 0, AddedOn = dt, ModifiedOn = dt },
                        new Equipment{ Name = "冷卻泵浦(一)",Seq = 12, Value = 0, AddedOn = dt, ModifiedOn = dt },
                        new Equipment{ Name = "冷卻泵浦SP",Seq = 13, Value = 0, AddedOn = dt, ModifiedOn = dt },
                        new Equipment{ Name = "冷卻泵浦(二)",Seq = 14, Value = 0, AddedOn = dt, ModifiedOn = dt },
                        new Equipment{ Name = "冰水泵浦(一)",Seq = 15, Value = 0, AddedOn = dt, ModifiedOn = dt },
                        new Equipment{ Name = "冰水泵浦SP",Seq = 16, Value = 0, AddedOn = dt, ModifiedOn = dt },
                        new Equipment{ Name = "冰水泵浦(二)",Seq = 17, Value = 0, AddedOn = dt, ModifiedOn = dt },
                        new Equipment{ Name = "儲冰泵浦(一)",Seq = 18, Value = 0, AddedOn = dt, ModifiedOn = dt },
                        new Equipment{ Name = "儲冰泵浦SP",Seq = 19, Value = 0, AddedOn = dt, ModifiedOn = dt },
                        new Equipment{ Name = "儲冰泵浦(二)",Seq = 20, Value = 0, AddedOn = dt, ModifiedOn = dt },
                        new Equipment{ Name = "冷卻風扇(一)",Seq = 21, Value = 0, AddedOn = dt, ModifiedOn = dt },
                        new Equipment{ Name = "冷卻風扇(二)",Seq = 22, Value = 0, AddedOn = dt, ModifiedOn = dt },
                        new Equipment{ Name = "主機1-1",Seq = 23, Value = 0, AddedOn = dt, ModifiedOn = dt },
                        new Equipment{ Name = "主機1-2",Seq = 24, Value = 0, AddedOn = dt, ModifiedOn = dt },
                        new Equipment{ Name = "主機2-1",Seq = 25, Value = 0, AddedOn = dt, ModifiedOn = dt },
                        new Equipment{ Name = "主機2-2",Seq = 26, Value = 0, AddedOn = dt, ModifiedOn = dt },
                        new Equipment{ Name = "CV1啟動訊號",Seq = 27, Value = 1, AddedOn = dt, ModifiedOn = dt },
                    }
                },
                new EquipmentGroup
                {
                    Name="temperature",
                    Seq = 1,
                    AddedOn = dt,
                    Equipments = new List<Equipment>
                    {
                         new Equipment{ Name = "t0",Seq = 0, Value = 60.0, AddedOn = dt, ModifiedOn = dt, Desc="外氣溫度" },
                         new Equipment{ Name = "t1",Seq = 1, Value = 16.3, AddedOn = dt, ModifiedOn = dt, Desc="冰水主機(一)出口溫度" },
                         new Equipment{ Name = "t2",Seq = 2, Value = 15.4, AddedOn = dt, ModifiedOn = dt, Desc="冰水主機(二)出口溫度" },
                         new Equipment{ Name = "t3",Seq = 3, Value = 9.9, AddedOn = dt, ModifiedOn = dt, Desc="冷熱交換器冰水出口溫度" },
                         new Equipment{ Name = "t4",Seq = 4, Value = 13.1, AddedOn = dt, ModifiedOn = dt, Desc="冷熱交換器滷水出口溫度" },
                         new Equipment{ Name = "t5",Seq = 5, Value = 15.0, AddedOn = dt, ModifiedOn = dt, Desc="滷水(一)出口溫度" },
                         new Equipment{ Name = "t6",Seq = 6, Value = 4.2, AddedOn = dt, ModifiedOn = dt, Desc="滷水(二)出口溫度" },
                         new Equipment{ Name = "t7",Seq = 7, Value = 30.1, AddedOn = dt, ModifiedOn = dt, Desc="主機(一)冷卻水出口溫度" },
                         new Equipment{ Name = "t8",Seq = 8, Value = 29.2, AddedOn = dt, ModifiedOn = dt, Desc="主機(二)冷卻水出口溫度" },
                         new Equipment{ Name = "t9",Seq = 9, Value = 14.0, AddedOn = dt, ModifiedOn = dt, Desc="區域泵回流端(二) 綜合" },
                         new Equipment{ Name = "t10",Seq = 10, Value = 13.2, AddedOn = dt, ModifiedOn = dt, Desc="區域泵回流端(一) 建築" },
                         new Equipment{ Name = "t11",Seq = 11, Value = 29.0, AddedOn = dt, ModifiedOn = dt, Desc="主機(一)(二)冷卻水出口溫度" },
                         new Equipment{ Name = "t12",Seq = 12, Value = 11.9, AddedOn = dt, ModifiedOn = dt, Desc="入儲冰桶溫度" },
                         new Equipment{ Name = "t13",Seq = 13, Value = 2.5, AddedOn = dt, ModifiedOn = dt, Desc="出儲冰桶溫度" },
                         new Equipment{ Name = "t14",Seq = 14, Value = 14.1, AddedOn = dt, ModifiedOn = dt, Desc="區域水泵回水及水管溫度" },
                         new Equipment{ Name = "t15",Seq = 15, Value = 15.1, AddedOn = dt, ModifiedOn = dt, Desc="冰水泵回水及水管溫度" },
                         new Equipment{ Name = "t16",Seq = 16, Value = 10.8, AddedOn = dt, ModifiedOn = dt, Desc="區域水泵回水及水管溫度" },
                         new Equipment{ Name = "t17",Seq = 17, Value = 14.0, AddedOn = dt, ModifiedOn = dt, Desc="冰水泵回水及水管溫度" },
                    }
                },
                new EquipmentGroup
                {
                    Name="Flow_data",
                    Seq = 2,
                    AddedOn = dt,
                    Equipments = new List<Equipment>
                    {
                        new Equipment{ Name = "儲冰量",Seq = 0, Value = 41, AddedOn = dt, ModifiedOn = dt },
                        new Equipment{ Name = "戶外濕度",Seq = 1, Value = 99, AddedOn = dt, ModifiedOn = dt },
                        new Equipment{ Name = "空調主機補水量L(當日)",Seq = 2, Value = 0, AddedOn = dt, ModifiedOn = dt },
                        new Equipment{ Name = "空調主機補水量L",Seq = 3, Value = 20966, AddedOn = dt, ModifiedOn = dt },
                        new Equipment{ Name = "管理一館Rt/Hr",Seq = 4, Value = 68, AddedOn = dt, ModifiedOn = dt },
                        new Equipment{ Name = "建築一館Rt/Hr",Seq = 5, Value = 41, AddedOn = dt, ModifiedOn = dt },
                        new Equipment{ Name = "管理一館流量計",Seq = 6, Value = 2266, AddedOn = dt, ModifiedOn = dt },
                        new Equipment{ Name = "建築一館流量計",Seq = 7, Value = 1608, AddedOn = dt, ModifiedOn = dt },
                    }
                },
                new EquipmentGroup
                {
                    Name="Flow_status",
                    Seq = 3,
                    AddedOn = dt,
                    Equipments = new List<Equipment>
                    {
                        new Equipment{ Name = "F1",Seq = 0, Value = 0, AddedOn = dt, ModifiedOn = dt, Desc="冰水泵浦(一)" },
                        new Equipment{ Name = "F2",Seq = 1, Value = 0, AddedOn = dt, ModifiedOn = dt, Desc="冰水泵浦(二)" },
                        new Equipment{ Name = "F3",Seq = 2, Value = 1, AddedOn = dt, ModifiedOn = dt, Desc="溶冰泵浦" },
                        new Equipment{ Name = "F4",Seq = 3, Value = 1, AddedOn = dt, ModifiedOn = dt, Desc="滷水泵浦" },
                        new Equipment{ Name = "F5",Seq = 4, Value = 0, AddedOn = dt, ModifiedOn = dt, Desc="儲冰泵浦(一)" },
                        new Equipment{ Name = "F6",Seq = 5, Value = 1, AddedOn = dt, ModifiedOn = dt, Desc="儲冰泵浦(二)" },
                        new Equipment{ Name = "F7",Seq = 6, Value = 0, AddedOn = dt, ModifiedOn = dt, Desc="冷卻水泵浦(一)" },
                        new Equipment{ Name = "F8",Seq = 7, Value = 0, AddedOn = dt, ModifiedOn = dt, Desc="冷卻水泵浦(二)" },
                        new Equipment{ Name = "F9",Seq = 8, Value = 1, AddedOn = dt, ModifiedOn = dt, Desc="管理一館區域泵浦" },
                        new Equipment{ Name = "F10",Seq = 9, Value = 1, AddedOn = dt, ModifiedOn = dt, Desc="建築一館區域泵浦" },
                    }
                },
                new EquipmentGroup
                {
                    Name="Alarm",
                    Seq = 4,
                    AddedOn = dt,
                    Equipments = new List<Equipment>
                    {
                        new Equipment{ Name = "滷水融冰泵浦異常",Seq = 0, Value = 1, AddedOn = dt, ModifiedOn = dt},
                        new Equipment{ Name = "冰水融冰泵浦異常",Seq = 1, Value = 0, AddedOn = dt, ModifiedOn = dt},
                        new Equipment{ Name = "管理一管泵浦異常",Seq = 2, Value = 0, AddedOn = dt, ModifiedOn = dt},
                        new Equipment{ Name = "建築區泵浦異常",Seq = 3, Value = 0, AddedOn = dt, ModifiedOn = dt},
                        new Equipment{ Name = "冰水泵浦(一)異常",Seq = 4, Value = 0, AddedOn = dt, ModifiedOn = dt},
                        new Equipment{ Name = "冷卻泵浦(一)異常",Seq = 5, Value = 0, AddedOn = dt, ModifiedOn = dt},
                        new Equipment{ Name = "冰水泵浦(二)異常",Seq = 6, Value = 0, AddedOn = dt, ModifiedOn = dt},
                        new Equipment{ Name = "冷卻泵浦(二)異常",Seq = 7, Value = 0, AddedOn = dt, ModifiedOn = dt},
                        new Equipment{ Name = "儲冰泵浦(一)異常",Seq = 8, Value = 0, AddedOn = dt, ModifiedOn = dt},
                        new Equipment{ Name = "儲冰泵浦(二)異常",Seq = 9, Value = 0, AddedOn = dt, ModifiedOn = dt},
                        new Equipment{ Name = "冰水主機(一)號異常",Seq = 10, Value = 0, AddedOn = dt, ModifiedOn = dt},
                        new Equipment{ Name = "冰水主機(二)號異常",Seq = 11, Value = 0, AddedOn = dt, ModifiedOn = dt},
                    }
                }

            };
            context.EquipmentGroup.AddRange(equipmentGroups);
            context.SaveChanges();
            // 事件記錄清單
            var oldDt = dt.AddHours(-2);
            var eventLogs = new List<EventLog>
            {
                new EventLog {SystemName="冰水主機",EventType="訊息",Content="溶冰啟動訊號運轉中",AddedOn=oldDt},
                new EventLog {SystemName="冰水主機",EventType="訊息",Content="區域泵浦(二)運轉中",AddedOn=oldDt},
                new EventLog {SystemName="冰水主機",EventType="訊息",Content="滷水泵浦(一)運轉中",AddedOn=oldDt}
            };
            context.EventLog.AddRange(eventLogs);
            context.SaveChanges();
            // User
            var user = new User { Email = "admin@mail.com", Password = "0000", AddedOn = dt };
            context.User.Add(user);
            context.SaveChanges();
        }
    }
}
