using CHUACSystem.Api.Services;
using CHUACSystem.Data;
using CHUACSystem.Repo;
using CHUACSystem.Service;
using CHUACSystem.Service.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace CHUACSystem.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ACSystemDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ACSystemDbContext")));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(AuthService));
            services.AddTransient<IPowerMeterService, PowerMeterService>();
            services.AddTransient<IHostGroupService, HostGroupService>();
            services.AddTransient<IEquipTempSettingService, EquipTempSettingService>();
            services.AddTransient<IFlowStatusService, FlowStatusService>();
            services.AddTransient<IEquipConnService, EquipConnService>();
            services.AddTransient<ITempSettingService, TempSettingService>();
            services.AddTransient<IOutTempSettingService, OutTempSettingService>();
            services.AddTransient<IOtherSettingService, OtherSettingService>();
            services.AddTransient<IClassroomGroupService, ClassroomGroupService>();
            services.AddTransient<ITemporaryClassService, TemporaryClassService>();
            services.AddTransient<ITemperatureHistoryService, TemperatureHistoryService>();
            services.AddTransient<IEquipmentGroupService, EquipmentGroupService>();
            services.AddTransient<IEventLogService, EventLogService>();
            services.AddTransient<IUserService, UserService>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", p =>
                {
                    p.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // The signing key must match!  
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),

                        // Validate the JWT Issuer (iss) claim  
                        ValidateIssuer = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],

                        // Validate the JWT Audience (aud) claim  
                        ValidateAudience = true,
                        ValidAudience = Configuration["Jwt:Issuer"],

                        // Validate the token expiry  
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                    };
                }
            );

            // ASP.NET Core Web API 很貼心的把回傳物件格式預設為 JSON camelCase
            services.AddMvc().AddJsonOptions(options =>
            {
                // 在轉型的過程中如果找不到欄位會自動轉成 null，不想傳送數值為 null 的欄位可以這樣設定
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            }); ;

            // register a WebSocket manager as a service to be able to broadcast data to browsers
            services.AddSingleton<ACSystemSocketManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseWebSockets();
            app.UseMiddleware<ChatWebSocketMiddleware>();
            app.UseCors("AllowAll");
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
