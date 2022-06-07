using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Token.Management.EntityFrameworkCore.Migrations
{
    public partial class CreateData : Migration
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
                name: "token_company",
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
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_token_company", x => x.Id);
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
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_token_menu", x => x.Id);
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
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_token_role", x => x.Id);
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
                    WorkFormId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_token_system_message", x => x.Id);
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
                    Status = table.Column<int>(type: "int", nullable: false, comment: "状态"),
                    MobileNumber = table.Column<long>(type: "bigint", maxLength: 11, nullable: true),
                    EMail = table.Column<string>(type: "longtext", nullable: true, comment: "邮箱")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_token_user_info", x => x.Id);
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
                    WorkFlowNodeStatus = table.Column<int>(type: "int", nullable: false),
                    SubmitTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_token_work_demo_main", x => x.Id);
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
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_token_workflow_template", x => x.Id);
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
                    UserInfoId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_token_department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_token_department_token_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "token_company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    UserInfoId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_token_menu_role_function", x => x.Id);
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
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_token_user_role_function", x => x.Id);
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
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_token_workflow_instance", x => x.Id);
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
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_token_workflow_node_template", x => x.Id);
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
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_token_user_department_function", x => x.Id);
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
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_token_workflow_approvers", x => x.Id);
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
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_token_workflowNode_instance", x => x.Id);
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
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_token_workflow_approval_role", x => x.Id);
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

            migrationBuilder.InsertData(
                table: "token_company",
                columns: new[] { "Id", "Code", "CreationTime", "Describe", "IsDeleted", "Logo", "Name" },
                values: new object[] { new Guid("5e69bd0f-1b25-459a-b5cb-bb7086821d1c"), "wr", new DateTime(2022, 6, 7, 23, 43, 5, 390, DateTimeKind.Local).AddTicks(6630), "微软（Microsoft）是一家 美国 跨国科技企业，由 比尔·盖茨 和 保罗·艾伦 于1975年4月4日创立。 公司总部设立在 华盛顿州 雷德蒙德 （Redmond，邻近 西雅图 ），以 研发 、 制造 、 授权 和提供广泛的 电脑软件 服务业务为主 。", false, null, "Microsoft" });

            migrationBuilder.InsertData(
                table: "token_menu",
                columns: new[] { "Id", "Component", "CreationTime", "Icon", "Index", "IsDeleted", "Name", "ParentId", "Path", "Title" },
                values: new object[,]
                {
                    { new Guid("05abe233-4252-499e-b91b-5721d784ab36"), "RoleConfig", new DateTime(2022, 6, 7, 23, 43, 5, 390, DateTimeKind.Local).AddTicks(6630), null, 0, false, "角色配置", new Guid("fafbe9c5-6b41-4981-8ebc-f30917b32c87"), "/system/roleConfig/index", "角色配置" },
                    { new Guid("4ac2f4d0-990b-4be1-9409-46fe034b2aa4"), "UserConfig", new DateTime(2022, 6, 7, 23, 43, 5, 390, DateTimeKind.Local).AddTicks(6630), null, 1, false, "用户权限配置", new Guid("fafbe9c5-6b41-4981-8ebc-f30917b32c87"), "/system/userConfig/index", "用户权限配置" },
                    { new Guid("5b3c39c8-f212-4105-85ae-cf34422d6026"), "Work", new DateTime(2022, 6, 7, 23, 43, 5, 390, DateTimeKind.Local).AddTicks(6630), null, 3, false, "工作", null, "/Work/index", "工作" },
                    { new Guid("5de1db7f-d249-43f5-9230-3833544b87b1"), "Home", new DateTime(2022, 6, 7, 23, 43, 5, 390, DateTimeKind.Local).AddTicks(6630), null, 0, false, "首页", null, "/home/index", "首页" },
                    { new Guid("da57bf0e-6c03-4ef4-a2ac-0cf576c3b0b5"), "User", new DateTime(2022, 6, 7, 23, 43, 5, 390, DateTimeKind.Local).AddTicks(6630), null, 1, false, "用户管理", null, "/user/index", "用户管理" },
                    { new Guid("fafbe9c5-6b41-4981-8ebc-f30917b32c87"), "System", new DateTime(2022, 6, 7, 23, 43, 5, 390, DateTimeKind.Local).AddTicks(6630), null, 2, false, "系统配置", null, "/system/index", "系统配置" },
                    { new Guid("fbfdfdb4-69ea-46d9-8740-d62ffb22f87d"), "WorkConfig", new DateTime(2022, 6, 7, 23, 43, 5, 390, DateTimeKind.Local).AddTicks(6630), null, 2, false, "工作流配置", new Guid("fafbe9c5-6b41-4981-8ebc-f30917b32c87"), "/system/workConfig/index", "工作流配置" }
                });

            migrationBuilder.InsertData(
                table: "token_role",
                columns: new[] { "Id", "Code", "CreationTime", "Index", "IsDeleted", "Name", "ParentId", "Remark" },
                values: new object[] { new Guid("5610d63a-183d-47a4-ab82-5d308ac15b8d"), "admin", new DateTime(2022, 6, 7, 23, 43, 5, 390, DateTimeKind.Local).AddTicks(6630), 0, false, "管理员", null, "系统管理员" });

            migrationBuilder.InsertData(
                table: "token_user_info",
                columns: new[] { "Id", "AccountNumber", "CreationTime", "EMail", "HeadPortraits", "IsDeleted", "MobileNumber", "Name", "Password", "Sex", "Status", "WXOpenId" },
                values: new object[] { new Guid("665203a9-6328-4358-a1f2-6588802c393b"), "admin", new DateTime(2022, 6, 7, 23, 43, 5, 390, DateTimeKind.Local).AddTicks(6630), "239573049@qq.com", "https://upfile2.asqql.com/upfile/hdimg/wmtp/wmtp/2018-07/08/18_7_8_16_10_08yoqapqci.jpg", false, 13049809673L, "管理员", "349843DE4F81CDE9456ADEACACE77ECF8DA4197169214575", 1, 0, null });

            migrationBuilder.InsertData(
                table: "token_department",
                columns: new[] { "Id", "Code", "CompanyId", "CreationTime", "Index", "IsDeleted", "Name", "ParentId", "UserInfoId" },
                values: new object[] { new Guid("96017ff8-52cd-4d85-b7b8-474b1bf51de0"), "cs", new Guid("5e69bd0f-1b25-459a-b5cb-bb7086821d1c"), new DateTime(2022, 6, 7, 23, 43, 5, 390, DateTimeKind.Local).AddTicks(6630), 0, false, "测试部门", null, null });

            migrationBuilder.InsertData(
                table: "token_menu_role_function",
                columns: new[] { "Id", "CreationTime", "IsDeleted", "MenuId", "RoleId", "UserInfoId" },
                values: new object[,]
                {
                    { new Guid("07109f16-fa61-41c7-a396-1ff420c46da7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("4ac2f4d0-990b-4be1-9409-46fe034b2aa4"), new Guid("5610d63a-183d-47a4-ab82-5d308ac15b8d"), null },
                    { new Guid("1ab255af-c439-425c-b2a8-767bd3a801f7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("05abe233-4252-499e-b91b-5721d784ab36"), new Guid("5610d63a-183d-47a4-ab82-5d308ac15b8d"), null },
                    { new Guid("3522f2b4-d35b-4913-8425-7c5e3006aa21"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("da57bf0e-6c03-4ef4-a2ac-0cf576c3b0b5"), new Guid("5610d63a-183d-47a4-ab82-5d308ac15b8d"), null },
                    { new Guid("d879ae65-3f52-4870-bf6e-83c94dc66bb0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("fafbe9c5-6b41-4981-8ebc-f30917b32c87"), new Guid("5610d63a-183d-47a4-ab82-5d308ac15b8d"), null },
                    { new Guid("d8aac5ab-557e-4d1d-9a86-7d9a9d0e6cef"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("fbfdfdb4-69ea-46d9-8740-d62ffb22f87d"), new Guid("5610d63a-183d-47a4-ab82-5d308ac15b8d"), null },
                    { new Guid("f51c106b-2e88-4739-b259-1c97d380f6f9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("5b3c39c8-f212-4105-85ae-cf34422d6026"), new Guid("5610d63a-183d-47a4-ab82-5d308ac15b8d"), null },
                    { new Guid("f808acc8-a746-46ee-b1be-97d7decd254c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("5de1db7f-d249-43f5-9230-3833544b87b1"), new Guid("5610d63a-183d-47a4-ab82-5d308ac15b8d"), null }
                });

            migrationBuilder.InsertData(
                table: "token_user_role_function",
                columns: new[] { "Id", "CreationTime", "IsDeleted", "RoleId", "UserInfoId" },
                values: new object[] { new Guid("6ee0907d-bb79-4b6c-9c96-f6d8b3f5a958"), new DateTime(2022, 6, 7, 23, 43, 5, 390, DateTimeKind.Local).AddTicks(6630), false, new Guid("5610d63a-183d-47a4-ab82-5d308ac15b8d"), new Guid("665203a9-6328-4358-a1f2-6588802c393b") });

            migrationBuilder.InsertData(
                table: "token_user_department_function",
                columns: new[] { "Id", "CreationTime", "DepartmentId", "IsDeleted", "UserInfoId" },
                values: new object[] { new Guid("c320a3d6-40b8-48cc-ab80-74a4a7f120cd"), new DateTime(2022, 6, 7, 23, 43, 5, 390, DateTimeKind.Local).AddTicks(6630), new Guid("96017ff8-52cd-4d85-b7b8-474b1bf51de0"), false, new Guid("665203a9-6328-4358-a1f2-6588802c393b") });

            migrationBuilder.CreateIndex(
                name: "IX_token_company_Id",
                table: "token_company",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_token_department_CompanyId",
                table: "token_department",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_token_department_Id",
                table: "token_department",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_token_department_UserInfoId",
                table: "token_department",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_token_menu_Id",
                table: "token_menu",
                column: "Id");

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
                name: "IX_token_role_Id",
                table: "token_role",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_token_system_message_Id",
                table: "token_system_message",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_token_user_department_function_DepartmentId",
                table: "token_user_department_function",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_token_user_department_function_Id",
                table: "token_user_department_function",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_token_user_department_function_UserInfoId",
                table: "token_user_department_function",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_token_user_info_Id",
                table: "token_user_info",
                column: "Id");

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
                name: "IX_token_work_demo_main_Id",
                table: "token_work_demo_main",
                column: "Id");

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
                name: "IX_token_workflow_approvers_Id",
                table: "token_workflow_approvers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_token_workflow_approvers_WorkflowInstanceId",
                table: "token_workflow_approvers",
                column: "WorkflowInstanceId");

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
                name: "IX_token_workflow_node_template_Id",
                table: "token_workflow_node_template",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_token_workflow_node_template_WorkflowTemplateId",
                table: "token_workflow_node_template",
                column: "WorkflowTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_token_workflow_template_Id",
                table: "token_workflow_template",
                column: "Id");

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
                name: "ExtraPropertyDictionary");

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
                name: "token_company");

            migrationBuilder.DropTable(
                name: "token_user_info");

            migrationBuilder.DropTable(
                name: "token_workflow_template");
        }
    }
}
