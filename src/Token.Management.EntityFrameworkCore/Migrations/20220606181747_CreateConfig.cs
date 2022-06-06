using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Token.Management.EntityFrameworkCore.Migrations
{
    public partial class CreateConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ExtraPropertyDictionary",
                columns: table => new
                {
                    Count = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraPropertyDictionary", x => x.Count);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Logo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Describe = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ExtraPropertiesCount = table.Column<int>(type: "int", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_ExtraPropertyDictionary_ExtraPropertiesCount",
                        column: x => x.ExtraPropertiesCount,
                        principalTable: "ExtraPropertyDictionary",
                        principalColumn: "Count");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "token_menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Index = table.Column<int>(type: "int", nullable: false),
                    Component = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Icon = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Path = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ParentId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ExtraPropertiesCount = table.Column<int>(type: "int", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_token_menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_token_menu_ExtraPropertyDictionary_ExtraPropertiesCount",
                        column: x => x.ExtraPropertiesCount,
                        principalTable: "ExtraPropertyDictionary",
                        principalColumn: "Count");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "token_role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true, comment: "角色名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "longtext", nullable: true, comment: "角色编号")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Remark = table.Column<string>(type: "longtext", nullable: true, comment: "备注")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Index = table.Column<int>(type: "int", nullable: false, comment: "序号"),
                    ParentId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "父节点", collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ExtraPropertiesCount = table.Column<int>(type: "int", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_token_role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_token_role_ExtraPropertyDictionary_ExtraPropertiesCount",
                        column: x => x.ExtraPropertiesCount,
                        principalTable: "ExtraPropertyDictionary",
                        principalColumn: "Count");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "token_system_message",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Message = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsCheck = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    WorkFormCode = table.Column<int>(type: "int", nullable: false),
                    WorkFormId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ExtraPropertiesCount = table.Column<int>(type: "int", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_token_system_message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_token_system_message_ExtraPropertyDictionary_ExtraProperties~",
                        column: x => x.ExtraPropertiesCount,
                        principalTable: "ExtraPropertyDictionary",
                        principalColumn: "Count");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "token_user_info",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AccountNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: true, comment: "密码")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WXOpenId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true, comment: "用户昵称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HeadPortraits = table.Column<string>(type: "longtext", nullable: true, comment: "头像")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sex = table.Column<int>(type: "int", nullable: false, comment: "性别"),
                    Statue = table.Column<int>(type: "int", nullable: false, comment: "状态"),
                    MobileNumber = table.Column<long>(type: "bigint", maxLength: 11, nullable: true),
                    EMail = table.Column<string>(type: "longtext", nullable: true, comment: "邮箱")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ExtraPropertiesCount = table.Column<int>(type: "int", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_token_user_info", x => x.Id);
                    table.ForeignKey(
                        name: "FK_token_user_info_ExtraPropertyDictionary_ExtraPropertiesCount",
                        column: x => x.ExtraPropertiesCount,
                        principalTable: "ExtraPropertyDictionary",
                        principalColumn: "Count");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "token_work_demo_main",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Remark = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Content = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Count = table.Column<int>(type: "int", nullable: false),
                    ExtraPropertiesCount = table.Column<int>(type: "int", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkFlowNodeStatus = table.Column<int>(type: "int", nullable: false),
                    SubmitTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_token_work_demo_main", x => x.Id);
                    table.ForeignKey(
                        name: "FK_token_work_demo_main_ExtraPropertyDictionary_ExtraProperties~",
                        column: x => x.ExtraPropertiesCount,
                        principalTable: "ExtraPropertyDictionary",
                        principalColumn: "Count");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "token_workflow_template",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true, comment: "工作流模板名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "longtext", nullable: true, comment: "工作流模板编号")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Remark = table.Column<string>(type: "longtext", nullable: true, comment: "工作流模板备注")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ExtraPropertiesCount = table.Column<int>(type: "int", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_token_workflow_template", x => x.Id);
                    table.ForeignKey(
                        name: "FK_token_workflow_template_ExtraPropertyDictionary_ExtraPropert~",
                        column: x => x.ExtraPropertiesCount,
                        principalTable: "ExtraPropertyDictionary",
                        principalColumn: "Count");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "token_department",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ParentId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Index = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserInfoId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ExtraPropertiesCount = table.Column<int>(type: "int", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_token_department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_token_department_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_token_department_ExtraPropertyDictionary_ExtraPropertiesCount",
                        column: x => x.ExtraPropertiesCount,
                        principalTable: "ExtraPropertyDictionary",
                        principalColumn: "Count");
                    table.ForeignKey(
                        name: "FK_token_department_token_user_info_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "token_user_info",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "token_menu_role_function",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MenuId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserInfoId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ExtraPropertiesCount = table.Column<int>(type: "int", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_token_menu_role_function", x => x.Id);
                    table.ForeignKey(
                        name: "FK_token_menu_role_function_ExtraPropertyDictionary_ExtraProper~",
                        column: x => x.ExtraPropertiesCount,
                        principalTable: "ExtraPropertyDictionary",
                        principalColumn: "Count");
                    table.ForeignKey(
                        name: "FK_token_menu_role_function_token_menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "token_menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_token_menu_role_function_token_role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "token_role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_token_menu_role_function_token_user_info_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "token_user_info",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "token_user_role_function",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserInfoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ExtraPropertiesCount = table.Column<int>(type: "int", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_token_user_role_function", x => x.Id);
                    table.ForeignKey(
                        name: "FK_token_user_role_function_ExtraPropertyDictionary_ExtraProper~",
                        column: x => x.ExtraPropertiesCount,
                        principalTable: "ExtraPropertyDictionary",
                        principalColumn: "Count");
                    table.ForeignKey(
                        name: "FK_token_user_role_function_token_role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "token_role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_token_user_role_function_token_user_info_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "token_user_info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "token_workflow_instance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SponsorId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SponsorName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "longtext", nullable: true, comment: "工作流实例code")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Remark = table.Column<string>(type: "longtext", nullable: true, comment: "工作流实例备注")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkflowTemplateId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WorkFormId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WorkflowStatus = table.Column<int>(type: "int", nullable: false),
                    SponsoredDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    WorkFlowFormCode = table.Column<int>(type: "int", nullable: false),
                    ArchiveDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    HasBeenRead = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CurrentRoleCode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ExtraPropertiesCount = table.Column<int>(type: "int", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_token_workflow_instance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_token_workflow_instance_ExtraPropertyDictionary_ExtraPropert~",
                        column: x => x.ExtraPropertiesCount,
                        principalTable: "ExtraPropertyDictionary",
                        principalColumn: "Count");
                    table.ForeignKey(
                        name: "FK_token_workflow_instance_token_user_info_SponsorId",
                        column: x => x.SponsorId,
                        principalTable: "token_user_info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_token_workflow_instance_token_workflow_template_WorkflowTemp~",
                        column: x => x.WorkflowTemplateId,
                        principalTable: "token_workflow_template",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "token_workflow_node_template",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WorkflowTemplateId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    PrevNodeId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    NextNodeId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Remark = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ExtraPropertiesCount = table.Column<int>(type: "int", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_token_workflow_node_template", x => x.Id);
                    table.ForeignKey(
                        name: "FK_token_workflow_node_template_ExtraPropertyDictionary_ExtraPr~",
                        column: x => x.ExtraPropertiesCount,
                        principalTable: "ExtraPropertyDictionary",
                        principalColumn: "Count");
                    table.ForeignKey(
                        name: "FK_token_workflow_node_template_token_workflow_template_Workflo~",
                        column: x => x.WorkflowTemplateId,
                        principalTable: "token_workflow_template",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "token_user_department_function",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserInfoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DepartmentId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ExtraPropertiesCount = table.Column<int>(type: "int", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_token_user_department_function", x => x.Id);
                    table.ForeignKey(
                        name: "FK_token_user_department_function_ExtraPropertyDictionary_Extra~",
                        column: x => x.ExtraPropertiesCount,
                        principalTable: "ExtraPropertyDictionary",
                        principalColumn: "Count");
                    table.ForeignKey(
                        name: "FK_token_user_department_function_token_department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "token_department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_token_user_department_function_token_user_info_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "token_user_info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "token_workflow_approvers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserInfoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkflowInstanceId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WorkFlowFormCode = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ExtraPropertiesCount = table.Column<int>(type: "int", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_token_workflow_approvers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_token_workflow_approvers_ExtraPropertyDictionary_ExtraProper~",
                        column: x => x.ExtraPropertiesCount,
                        principalTable: "ExtraPropertyDictionary",
                        principalColumn: "Count");
                    table.ForeignKey(
                        name: "FK_token_workflow_approvers_token_workflow_instance_WorkflowIns~",
                        column: x => x.WorkflowInstanceId,
                        principalTable: "token_workflow_instance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "token_workflowNode_instance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WorkflowInstanceId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    TemplateNodeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PrevTemplateNodeId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    NextTemplateNodeId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    PrevNodeId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    NextNodeId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Remark = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPersonId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    AuditPersonName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    NodeStatus = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ExtraPropertiesCount = table.Column<int>(type: "int", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_token_workflowNode_instance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_token_workflowNode_instance_ExtraPropertyDictionary_ExtraPro~",
                        column: x => x.ExtraPropertiesCount,
                        principalTable: "ExtraPropertyDictionary",
                        principalColumn: "Count");
                    table.ForeignKey(
                        name: "FK_token_workflowNode_instance_token_workflow_instance_Workflow~",
                        column: x => x.WorkflowInstanceId,
                        principalTable: "token_workflow_instance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "token_workflow_approval_role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WorkflowNodeTemplateId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ExtraPropertiesCount = table.Column<int>(type: "int", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_token_workflow_approval_role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_token_workflow_approval_role_ExtraPropertyDictionary_ExtraPr~",
                        column: x => x.ExtraPropertiesCount,
                        principalTable: "ExtraPropertyDictionary",
                        principalColumn: "Count");
                    table.ForeignKey(
                        name: "FK_token_workflow_approval_role_token_role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "token_role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_token_workflow_approval_role_token_workflow_node_template_Wo~",
                        column: x => x.WorkflowNodeTemplateId,
                        principalTable: "token_workflow_node_template",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Company_ExtraPropertiesCount",
                table: "Company",
                column: "ExtraPropertiesCount");

            migrationBuilder.CreateIndex(
                name: "IX_token_department_CompanyId",
                table: "token_department",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_token_department_ExtraPropertiesCount",
                table: "token_department",
                column: "ExtraPropertiesCount");

            migrationBuilder.CreateIndex(
                name: "IX_token_department_Id",
                table: "token_department",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_token_department_UserInfoId",
                table: "token_department",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_token_menu_ExtraPropertiesCount",
                table: "token_menu",
                column: "ExtraPropertiesCount");

            migrationBuilder.CreateIndex(
                name: "IX_token_menu_Id",
                table: "token_menu",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_token_menu_role_function_ExtraPropertiesCount",
                table: "token_menu_role_function",
                column: "ExtraPropertiesCount");

            migrationBuilder.CreateIndex(
                name: "IX_token_menu_role_function_Id",
                table: "token_menu_role_function",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_token_menu_role_function_MenuId",
                table: "token_menu_role_function",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_token_menu_role_function_RoleId",
                table: "token_menu_role_function",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_token_menu_role_function_UserInfoId",
                table: "token_menu_role_function",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_token_role_ExtraPropertiesCount",
                table: "token_role",
                column: "ExtraPropertiesCount");

            migrationBuilder.CreateIndex(
                name: "IX_token_role_Id",
                table: "token_role",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_token_system_message_ExtraPropertiesCount",
                table: "token_system_message",
                column: "ExtraPropertiesCount");

            migrationBuilder.CreateIndex(
                name: "IX_token_system_message_Id",
                table: "token_system_message",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_token_user_department_function_DepartmentId",
                table: "token_user_department_function",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_token_user_department_function_ExtraPropertiesCount",
                table: "token_user_department_function",
                column: "ExtraPropertiesCount");

            migrationBuilder.CreateIndex(
                name: "IX_token_user_department_function_Id",
                table: "token_user_department_function",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_token_user_department_function_UserInfoId",
                table: "token_user_department_function",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_token_user_info_ExtraPropertiesCount",
                table: "token_user_info",
                column: "ExtraPropertiesCount");

            migrationBuilder.CreateIndex(
                name: "IX_token_user_info_Id",
                table: "token_user_info",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_token_user_role_function_ExtraPropertiesCount",
                table: "token_user_role_function",
                column: "ExtraPropertiesCount");

            migrationBuilder.CreateIndex(
                name: "IX_token_user_role_function_Id",
                table: "token_user_role_function",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_token_user_role_function_RoleId",
                table: "token_user_role_function",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_token_user_role_function_UserInfoId",
                table: "token_user_role_function",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_token_work_demo_main_ExtraPropertiesCount",
                table: "token_work_demo_main",
                column: "ExtraPropertiesCount");

            migrationBuilder.CreateIndex(
                name: "IX_token_work_demo_main_Id",
                table: "token_work_demo_main",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_token_workflow_approval_role_ExtraPropertiesCount",
                table: "token_workflow_approval_role",
                column: "ExtraPropertiesCount");

            migrationBuilder.CreateIndex(
                name: "IX_token_workflow_approval_role_Id",
                table: "token_workflow_approval_role",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_token_workflow_approval_role_RoleId",
                table: "token_workflow_approval_role",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_token_workflow_approval_role_WorkflowNodeTemplateId",
                table: "token_workflow_approval_role",
                column: "WorkflowNodeTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_token_workflow_approvers_ExtraPropertiesCount",
                table: "token_workflow_approvers",
                column: "ExtraPropertiesCount");

            migrationBuilder.CreateIndex(
                name: "IX_token_workflow_approvers_Id",
                table: "token_workflow_approvers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_token_workflow_approvers_WorkflowInstanceId",
                table: "token_workflow_approvers",
                column: "WorkflowInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_token_workflow_instance_ExtraPropertiesCount",
                table: "token_workflow_instance",
                column: "ExtraPropertiesCount");

            migrationBuilder.CreateIndex(
                name: "IX_token_workflow_instance_Id",
                table: "token_workflow_instance",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_token_workflow_instance_SponsorId",
                table: "token_workflow_instance",
                column: "SponsorId");

            migrationBuilder.CreateIndex(
                name: "IX_token_workflow_instance_WorkflowTemplateId",
                table: "token_workflow_instance",
                column: "WorkflowTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_token_workflow_node_template_ExtraPropertiesCount",
                table: "token_workflow_node_template",
                column: "ExtraPropertiesCount");

            migrationBuilder.CreateIndex(
                name: "IX_token_workflow_node_template_Id",
                table: "token_workflow_node_template",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_token_workflow_node_template_WorkflowTemplateId",
                table: "token_workflow_node_template",
                column: "WorkflowTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_token_workflow_template_ExtraPropertiesCount",
                table: "token_workflow_template",
                column: "ExtraPropertiesCount");

            migrationBuilder.CreateIndex(
                name: "IX_token_workflow_template_Id",
                table: "token_workflow_template",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_token_workflowNode_instance_ExtraPropertiesCount",
                table: "token_workflowNode_instance",
                column: "ExtraPropertiesCount");

            migrationBuilder.CreateIndex(
                name: "IX_token_workflowNode_instance_Id",
                table: "token_workflowNode_instance",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_token_workflowNode_instance_WorkflowInstanceId",
                table: "token_workflowNode_instance",
                column: "WorkflowInstanceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "token_menu_role_function");

            migrationBuilder.DropTable(
                name: "token_system_message");

            migrationBuilder.DropTable(
                name: "token_user_department_function");

            migrationBuilder.DropTable(
                name: "token_user_role_function");

            migrationBuilder.DropTable(
                name: "token_work_demo_main");

            migrationBuilder.DropTable(
                name: "token_workflow_approval_role");

            migrationBuilder.DropTable(
                name: "token_workflow_approvers");

            migrationBuilder.DropTable(
                name: "token_workflowNode_instance");

            migrationBuilder.DropTable(
                name: "token_menu");

            migrationBuilder.DropTable(
                name: "token_department");

            migrationBuilder.DropTable(
                name: "token_role");

            migrationBuilder.DropTable(
                name: "token_workflow_node_template");

            migrationBuilder.DropTable(
                name: "token_workflow_instance");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "token_user_info");

            migrationBuilder.DropTable(
                name: "token_workflow_template");

            migrationBuilder.DropTable(
                name: "ExtraPropertyDictionary");
        }
    }
}
