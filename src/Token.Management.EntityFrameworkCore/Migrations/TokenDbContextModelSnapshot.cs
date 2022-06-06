﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Token.Management.EntityFrameworkCore.EntityFrameworkCore;

#nullable disable

namespace Token.Management.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(TokenDbContext))]
    partial class TokenDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Token.Management.Domain.Management.AccessFunction.MenuRoleFunction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("ExtraPropertiesCount")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("MenuId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("UserInfoId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ExtraPropertiesCount");

                    b.HasIndex("Id");

                    b.HasIndex("MenuId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserInfoId");

                    b.ToTable("token_menu_role_function", (string)null);
                });

            modelBuilder.Entity("Token.Management.Domain.Management.AccessFunction.UserDepartmentFunction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("char(36)");

                    b.Property<int?>("ExtraPropertiesCount")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("UserInfoId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("ExtraPropertiesCount");

                    b.HasIndex("Id");

                    b.HasIndex("UserInfoId");

                    b.ToTable("token_user_department_function", (string)null);
                });

            modelBuilder.Entity("Token.Management.Domain.Management.AccessFunction.UserRoleFunction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("ExtraPropertiesCount")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserInfoId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ExtraPropertiesCount");

                    b.HasIndex("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserInfoId");

                    b.ToTable("token_user_role_function", (string)null);
                });

            modelBuilder.Entity("Token.Management.Domain.Management.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Code")
                        .HasColumnType("longtext");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Describe")
                        .HasColumnType("longtext");

                    b.Property<int?>("ExtraPropertiesCount")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Logo")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ExtraPropertiesCount");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("Token.Management.Domain.Management.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Code")
                        .HasColumnType("longtext");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("char(36)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("ExtraPropertiesCount")
                        .HasColumnType("int");

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("UserInfoId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ExtraPropertiesCount");

                    b.HasIndex("Id");

                    b.HasIndex("UserInfoId");

                    b.ToTable("token_department", (string)null);
                });

            modelBuilder.Entity("Token.Management.Domain.Management.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Component")
                        .HasColumnType("longtext");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("ExtraPropertiesCount")
                        .HasColumnType("int");

                    b.Property<string>("Icon")
                        .HasColumnType("longtext");

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Path")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ExtraPropertiesCount");

                    b.HasIndex("Id");

                    b.ToTable("token_menu", (string)null);
                });

            modelBuilder.Entity("Token.Management.Domain.Management.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Code")
                        .HasColumnType("longtext")
                        .HasComment("角色编号");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("ExtraPropertiesCount")
                        .HasColumnType("int");

                    b.Property<int>("Index")
                        .HasColumnType("int")
                        .HasComment("序号");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext")
                        .HasComment("角色名称");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("char(36)")
                        .HasComment("父节点");

                    b.Property<string>("Remark")
                        .HasColumnType("longtext")
                        .HasComment("备注");

                    b.HasKey("Id");

                    b.HasIndex("ExtraPropertiesCount");

                    b.HasIndex("Id");

                    b.ToTable("token_role", (string)null);
                });

            modelBuilder.Entity("Token.Management.Domain.SystemService.SystemMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<int?>("ExtraPropertiesCount")
                        .HasColumnType("int");

                    b.Property<bool>("IsCheck")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Message")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<int>("WorkFormCode")
                        .HasColumnType("int");

                    b.Property<Guid?>("WorkFormId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ExtraPropertiesCount");

                    b.HasIndex("Id");

                    b.ToTable("token_system_message", (string)null);
                });

            modelBuilder.Entity("Token.Management.Domain.Users.UserInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("EMail")
                        .HasColumnType("longtext")
                        .HasComment("邮箱");

                    b.Property<int?>("ExtraPropertiesCount")
                        .HasColumnType("int");

                    b.Property<string>("HeadPortraits")
                        .HasColumnType("longtext")
                        .HasComment("头像");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<long?>("MobileNumber")
                        .HasMaxLength(11)
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("longtext")
                        .HasComment("用户昵称");

                    b.Property<string>("Password")
                        .HasColumnType("longtext")
                        .HasComment("密码");

                    b.Property<int>("Sex")
                        .HasColumnType("int")
                        .HasComment("性别");

                    b.Property<int>("Statue")
                        .HasColumnType("int")
                        .HasComment("状态");

                    b.Property<string>("WXOpenId")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ExtraPropertiesCount");

                    b.HasIndex("Id");

                    b.ToTable("token_user_info", (string)null);
                });

            modelBuilder.Entity("Token.Management.Domain.WorkContent.WorkDemoMain", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<string>("Content")
                        .HasColumnType("longtext");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int?>("ExtraPropertiesCount")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Remark")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("SubmitTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("WorkFlowNodeStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExtraPropertiesCount");

                    b.HasIndex("Id");

                    b.ToTable("token_work_demo_main", (string)null);
                });

            modelBuilder.Entity("Token.Management.Domain.WorkFlow.WorkflowApprovalRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<int?>("ExtraPropertiesCount")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("WorkflowNodeTemplateId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ExtraPropertiesCount");

                    b.HasIndex("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("WorkflowNodeTemplateId");

                    b.ToTable("token_workflow_approval_role", (string)null);
                });

            modelBuilder.Entity("Token.Management.Domain.WorkFlow.WorkflowApprovers", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<int?>("ExtraPropertiesCount")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("UserInfoId")
                        .HasColumnType("char(36)");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.Property<int>("WorkFlowFormCode")
                        .HasColumnType("int");

                    b.Property<Guid>("WorkflowInstanceId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ExtraPropertiesCount");

                    b.HasIndex("Id");

                    b.HasIndex("WorkflowInstanceId");

                    b.ToTable("token_workflow_approvers", (string)null);
                });

            modelBuilder.Entity("Token.Management.Domain.WorkFlow.WorkflowInstance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("ArchiveDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Code")
                        .HasColumnType("longtext")
                        .HasComment("工作流实例code");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<string>("CurrentRoleCode")
                        .HasColumnType("longtext");

                    b.Property<int?>("ExtraPropertiesCount")
                        .HasColumnType("int");

                    b.Property<bool>("HasBeenRead")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Remark")
                        .HasColumnType("longtext")
                        .HasComment("工作流实例备注");

                    b.Property<Guid>("SponsorId")
                        .HasColumnType("char(36)");

                    b.Property<string>("SponsorName")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("SponsoredDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("WorkFlowFormCode")
                        .HasColumnType("int");

                    b.Property<Guid>("WorkFormId")
                        .HasColumnType("char(36)");

                    b.Property<int>("WorkflowStatus")
                        .HasColumnType("int");

                    b.Property<Guid>("WorkflowTemplateId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ExtraPropertiesCount");

                    b.HasIndex("Id");

                    b.HasIndex("SponsorId");

                    b.HasIndex("WorkflowTemplateId");

                    b.ToTable("token_workflow_instance", (string)null);
                });

            modelBuilder.Entity("Token.Management.Domain.WorkFlow.WorkflowNodeInstance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("AuditDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("AuditPersonId")
                        .HasColumnType("char(36)");

                    b.Property<string>("AuditPersonName")
                        .HasColumnType("longtext");

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<int?>("ExtraPropertiesCount")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("NextNodeId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("NextTemplateNodeId")
                        .HasColumnType("char(36)");

                    b.Property<int>("NodeStatus")
                        .HasColumnType("int");

                    b.Property<Guid?>("PrevNodeId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("PrevTemplateNodeId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Remark")
                        .HasColumnType("longtext");

                    b.Property<Guid>("TemplateNodeId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("WorkflowInstanceId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ExtraPropertiesCount");

                    b.HasIndex("Id");

                    b.HasIndex("WorkflowInstanceId");

                    b.ToTable("token_workflowNode_instance", (string)null);
                });

            modelBuilder.Entity("Token.Management.Domain.WorkFlow.WorkflowNodeTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<int?>("ExtraPropertiesCount")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid?>("NextNodeId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("PrevNodeId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Remark")
                        .HasColumnType("longtext");

                    b.Property<Guid>("WorkflowTemplateId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ExtraPropertiesCount");

                    b.HasIndex("Id");

                    b.HasIndex("WorkflowTemplateId");

                    b.ToTable("token_workflow_node_template", (string)null);
                });

            modelBuilder.Entity("Token.Management.Domain.WorkFlow.WorkflowTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Code")
                        .HasColumnType("longtext")
                        .HasComment("工作流模板编号");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<int?>("ExtraPropertiesCount")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext")
                        .HasComment("工作流模板名称");

                    b.Property<string>("Remark")
                        .HasColumnType("longtext")
                        .HasComment("工作流模板备注");

                    b.HasKey("Id");

                    b.HasIndex("ExtraPropertiesCount");

                    b.HasIndex("Id");

                    b.ToTable("token_workflow_template", (string)null);
                });

            modelBuilder.Entity("Volo.Abp.Data.ExtraPropertyDictionary", b =>
                {
                    b.Property<int>("Count")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.HasKey("Count");

                    b.ToTable("ExtraPropertyDictionary");
                });

            modelBuilder.Entity("Token.Management.Domain.Management.AccessFunction.MenuRoleFunction", b =>
                {
                    b.HasOne("Volo.Abp.Data.ExtraPropertyDictionary", "ExtraProperties")
                        .WithMany()
                        .HasForeignKey("ExtraPropertiesCount");

                    b.HasOne("Token.Management.Domain.Management.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Token.Management.Domain.Management.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Token.Management.Domain.Users.UserInfo", null)
                        .WithMany("MenuRoleFunction")
                        .HasForeignKey("UserInfoId");

                    b.Navigation("ExtraProperties");

                    b.Navigation("Menu");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Token.Management.Domain.Management.AccessFunction.UserDepartmentFunction", b =>
                {
                    b.HasOne("Token.Management.Domain.Management.Department", "Department")
                        .WithMany("UserDepartmentFunction")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Volo.Abp.Data.ExtraPropertyDictionary", "ExtraProperties")
                        .WithMany()
                        .HasForeignKey("ExtraPropertiesCount");

                    b.HasOne("Token.Management.Domain.Users.UserInfo", "UserInfo")
                        .WithMany("UserDepartmentFunction")
                        .HasForeignKey("UserInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("ExtraProperties");

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("Token.Management.Domain.Management.AccessFunction.UserRoleFunction", b =>
                {
                    b.HasOne("Volo.Abp.Data.ExtraPropertyDictionary", "ExtraProperties")
                        .WithMany()
                        .HasForeignKey("ExtraPropertiesCount");

                    b.HasOne("Token.Management.Domain.Management.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Token.Management.Domain.Users.UserInfo", "UserInfo")
                        .WithMany("UserRoleFunction")
                        .HasForeignKey("UserInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExtraProperties");

                    b.Navigation("Role");

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("Token.Management.Domain.Management.Company", b =>
                {
                    b.HasOne("Volo.Abp.Data.ExtraPropertyDictionary", "ExtraProperties")
                        .WithMany()
                        .HasForeignKey("ExtraPropertiesCount");

                    b.Navigation("ExtraProperties");
                });

            modelBuilder.Entity("Token.Management.Domain.Management.Department", b =>
                {
                    b.HasOne("Token.Management.Domain.Management.Company", "Company")
                        .WithMany("Department")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Volo.Abp.Data.ExtraPropertyDictionary", "ExtraProperties")
                        .WithMany()
                        .HasForeignKey("ExtraPropertiesCount");

                    b.HasOne("Token.Management.Domain.Users.UserInfo", null)
                        .WithMany("Department")
                        .HasForeignKey("UserInfoId");

                    b.Navigation("Company");

                    b.Navigation("ExtraProperties");
                });

            modelBuilder.Entity("Token.Management.Domain.Management.Menu", b =>
                {
                    b.HasOne("Volo.Abp.Data.ExtraPropertyDictionary", "ExtraProperties")
                        .WithMany()
                        .HasForeignKey("ExtraPropertiesCount");

                    b.Navigation("ExtraProperties");
                });

            modelBuilder.Entity("Token.Management.Domain.Management.Role", b =>
                {
                    b.HasOne("Volo.Abp.Data.ExtraPropertyDictionary", "ExtraProperties")
                        .WithMany()
                        .HasForeignKey("ExtraPropertiesCount");

                    b.Navigation("ExtraProperties");
                });

            modelBuilder.Entity("Token.Management.Domain.SystemService.SystemMessage", b =>
                {
                    b.HasOne("Volo.Abp.Data.ExtraPropertyDictionary", "ExtraProperties")
                        .WithMany()
                        .HasForeignKey("ExtraPropertiesCount");

                    b.Navigation("ExtraProperties");
                });

            modelBuilder.Entity("Token.Management.Domain.Users.UserInfo", b =>
                {
                    b.HasOne("Volo.Abp.Data.ExtraPropertyDictionary", "ExtraProperties")
                        .WithMany()
                        .HasForeignKey("ExtraPropertiesCount");

                    b.Navigation("ExtraProperties");
                });

            modelBuilder.Entity("Token.Management.Domain.WorkContent.WorkDemoMain", b =>
                {
                    b.HasOne("Volo.Abp.Data.ExtraPropertyDictionary", "ExtraProperties")
                        .WithMany()
                        .HasForeignKey("ExtraPropertiesCount");

                    b.Navigation("ExtraProperties");
                });

            modelBuilder.Entity("Token.Management.Domain.WorkFlow.WorkflowApprovalRole", b =>
                {
                    b.HasOne("Volo.Abp.Data.ExtraPropertyDictionary", "ExtraProperties")
                        .WithMany()
                        .HasForeignKey("ExtraPropertiesCount");

                    b.HasOne("Token.Management.Domain.Management.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Token.Management.Domain.WorkFlow.WorkflowNodeTemplate", "WorkflowNodeTemplate")
                        .WithMany("WorkflowApprovalRole")
                        .HasForeignKey("WorkflowNodeTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExtraProperties");

                    b.Navigation("Role");

                    b.Navigation("WorkflowNodeTemplate");
                });

            modelBuilder.Entity("Token.Management.Domain.WorkFlow.WorkflowApprovers", b =>
                {
                    b.HasOne("Volo.Abp.Data.ExtraPropertyDictionary", "ExtraProperties")
                        .WithMany()
                        .HasForeignKey("ExtraPropertiesCount");

                    b.HasOne("Token.Management.Domain.WorkFlow.WorkflowInstance", "WorkflowInstance")
                        .WithMany("WorkflowApprovers")
                        .HasForeignKey("WorkflowInstanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExtraProperties");

                    b.Navigation("WorkflowInstance");
                });

            modelBuilder.Entity("Token.Management.Domain.WorkFlow.WorkflowInstance", b =>
                {
                    b.HasOne("Volo.Abp.Data.ExtraPropertyDictionary", "ExtraProperties")
                        .WithMany()
                        .HasForeignKey("ExtraPropertiesCount");

                    b.HasOne("Token.Management.Domain.Users.UserInfo", "Sponsor")
                        .WithMany()
                        .HasForeignKey("SponsorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Token.Management.Domain.WorkFlow.WorkflowTemplate", "WorkflowTemplate")
                        .WithMany("WorkflowInstance")
                        .HasForeignKey("WorkflowTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExtraProperties");

                    b.Navigation("Sponsor");

                    b.Navigation("WorkflowTemplate");
                });

            modelBuilder.Entity("Token.Management.Domain.WorkFlow.WorkflowNodeInstance", b =>
                {
                    b.HasOne("Volo.Abp.Data.ExtraPropertyDictionary", "ExtraProperties")
                        .WithMany()
                        .HasForeignKey("ExtraPropertiesCount");

                    b.HasOne("Token.Management.Domain.WorkFlow.WorkflowInstance", "WorkflowInstance")
                        .WithMany("WorkflowNodeInstances")
                        .HasForeignKey("WorkflowInstanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExtraProperties");

                    b.Navigation("WorkflowInstance");
                });

            modelBuilder.Entity("Token.Management.Domain.WorkFlow.WorkflowNodeTemplate", b =>
                {
                    b.HasOne("Volo.Abp.Data.ExtraPropertyDictionary", "ExtraProperties")
                        .WithMany()
                        .HasForeignKey("ExtraPropertiesCount");

                    b.HasOne("Token.Management.Domain.WorkFlow.WorkflowTemplate", "WorkflowTemplate")
                        .WithMany("WorkflowNodeTemplate")
                        .HasForeignKey("WorkflowTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExtraProperties");

                    b.Navigation("WorkflowTemplate");
                });

            modelBuilder.Entity("Token.Management.Domain.WorkFlow.WorkflowTemplate", b =>
                {
                    b.HasOne("Volo.Abp.Data.ExtraPropertyDictionary", "ExtraProperties")
                        .WithMany()
                        .HasForeignKey("ExtraPropertiesCount");

                    b.Navigation("ExtraProperties");
                });

            modelBuilder.Entity("Token.Management.Domain.Management.Company", b =>
                {
                    b.Navigation("Department");
                });

            modelBuilder.Entity("Token.Management.Domain.Management.Department", b =>
                {
                    b.Navigation("UserDepartmentFunction");
                });

            modelBuilder.Entity("Token.Management.Domain.Users.UserInfo", b =>
                {
                    b.Navigation("Department");

                    b.Navigation("MenuRoleFunction");

                    b.Navigation("UserDepartmentFunction");

                    b.Navigation("UserRoleFunction");
                });

            modelBuilder.Entity("Token.Management.Domain.WorkFlow.WorkflowInstance", b =>
                {
                    b.Navigation("WorkflowApprovers");

                    b.Navigation("WorkflowNodeInstances");
                });

            modelBuilder.Entity("Token.Management.Domain.WorkFlow.WorkflowNodeTemplate", b =>
                {
                    b.Navigation("WorkflowApprovalRole");
                });

            modelBuilder.Entity("Token.Management.Domain.WorkFlow.WorkflowTemplate", b =>
                {
                    b.Navigation("WorkflowInstance");

                    b.Navigation("WorkflowNodeTemplate");
                });
#pragma warning restore 612, 618
        }
    }
}
