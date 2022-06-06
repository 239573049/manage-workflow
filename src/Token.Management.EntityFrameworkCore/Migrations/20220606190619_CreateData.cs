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
                    Statue = table.Column<int>(type: "int", nullable: false, comment: "状态"),
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
                values: new object[] { new Guid("aab77e0b-acca-427f-9b99-4192fcf857a6"), "wr", new DateTime(2022, 6, 7, 3, 6, 19, 15, DateTimeKind.Local).AddTicks(1666), "微软（Microsoft）是一家 美国 跨国科技企业，由 比尔·盖茨 和 保罗·艾伦 于1975年4月4日创立。 公司总部设立在 华盛顿州 雷德蒙德 （Redmond，邻近 西雅图 ），以 研发 、 制造 、 授权 和提供广泛的 电脑软件 服务业务为主 。", false, null, "Microsoft" });

            migrationBuilder.InsertData(
                table: "token_menu",
                columns: new[] { "Id", "Component", "CreationTime", "Icon", "Index", "IsDeleted", "Name", "ParentId", "Path", "Title" },
                values: new object[,]
                {
                    { new Guid("0436ce5c-847d-4f52-b899-23de0c0ffcad"), "WorkConfig", new DateTime(2022, 6, 7, 3, 6, 19, 15, DateTimeKind.Local).AddTicks(1666), null, 2, false, "工作流配置", new Guid("49b54056-ca0d-409f-a1d0-b28ca19ff6bc"), "/system/workConfig/index", "工作流配置" },
                    { new Guid("0e5f04f8-1ae2-4e19-bf8f-ddfeceb2cdd4"), "User", new DateTime(2022, 6, 7, 3, 6, 19, 15, DateTimeKind.Local).AddTicks(1666), null, 1, false, "用户管理", null, "/user/index", "用户管理" },
                    { new Guid("49b54056-ca0d-409f-a1d0-b28ca19ff6bc"), "System", new DateTime(2022, 6, 7, 3, 6, 19, 15, DateTimeKind.Local).AddTicks(1666), null, 2, false, "系统配置", null, "/system/index", "系统配置" },
                    { new Guid("5497a9e8-43ab-4de4-8695-999f0add8296"), "UserConfig", new DateTime(2022, 6, 7, 3, 6, 19, 15, DateTimeKind.Local).AddTicks(1666), null, 1, false, "用户权限配置", new Guid("49b54056-ca0d-409f-a1d0-b28ca19ff6bc"), "/system/userConfig/index", "用户权限配置" },
                    { new Guid("7cf394b0-a182-453d-b4eb-f9f899a6fa0d"), "Work", new DateTime(2022, 6, 7, 3, 6, 19, 15, DateTimeKind.Local).AddTicks(1666), null, 3, false, "工作", null, "/Work/index", "工作" },
                    { new Guid("7e8dbc94-c9f0-42d6-af32-25543090d534"), "Home", new DateTime(2022, 6, 7, 3, 6, 19, 15, DateTimeKind.Local).AddTicks(1666), null, 0, false, "首页", null, "/home/index", "首页" },
                    { new Guid("9b9a403a-fe51-43e1-966f-67c4e982beeb"), "RoleConfig", new DateTime(2022, 6, 7, 3, 6, 19, 15, DateTimeKind.Local).AddTicks(1666), null, 0, false, "角色配置", new Guid("49b54056-ca0d-409f-a1d0-b28ca19ff6bc"), "/system/roleConfig/index", "角色配置" }
                });

            migrationBuilder.InsertData(
                table: "token_role",
                columns: new[] { "Id", "Code", "CreationTime", "Index", "IsDeleted", "Name", "ParentId", "Remark" },
                values: new object[] { new Guid("f14bb479-6e36-47e9-af6e-0e8081c0be59"), "admin", new DateTime(2022, 6, 7, 3, 6, 19, 15, DateTimeKind.Local).AddTicks(1666), 0, false, "管理员", null, "系统管理员" });

            migrationBuilder.InsertData(
                table: "token_user_info",
                columns: new[] { "Id", "AccountNumber", "CreationTime", "EMail", "HeadPortraits", "IsDeleted", "MobileNumber", "Name", "Password", "Sex", "Statue", "WXOpenId" },
                values: new object[] { new Guid("db9555b3-c844-492a-9192-8649361cb75e"), "admin", new DateTime(2022, 6, 7, 3, 6, 19, 15, DateTimeKind.Local).AddTicks(1666), "239573049@qq.com", "https://upfile2.asqql.com/upfile/hdimg/wmtp/wmtp/2018-07/08/18_7_8_16_10_08yoqapqci.jpg", false, 13049809673L, "管理员", "Aa010426", 1, 0, null });

            migrationBuilder.InsertData(
                table: "token_department",
                columns: new[] { "Id", "Code", "CompanyId", "CreationTime", "Index", "IsDeleted", "Name", "ParentId", "UserInfoId" },
                values: new object[] { new Guid("bcf1021f-ed6e-4ac6-834b-84937dd741af"), "cs", new Guid("aab77e0b-acca-427f-9b99-4192fcf857a6"), new DateTime(2022, 6, 7, 3, 6, 19, 15, DateTimeKind.Local).AddTicks(1666), 0, false, "测试部门", null, null });

            migrationBuilder.InsertData(
                table: "token_menu_role_function",
                columns: new[] { "Id", "CreationTime", "IsDeleted", "MenuId", "RoleId", "UserInfoId" },
                values: new object[,]
                {
                    { new Guid("62c4c9cd-639c-4ca3-962d-cd6e4eb34c65"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("5497a9e8-43ab-4de4-8695-999f0add8296"), new Guid("f14bb479-6e36-47e9-af6e-0e8081c0be59"), null },
                    { new Guid("64a99844-8a45-4f1e-b136-dae5df44f695"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("7cf394b0-a182-453d-b4eb-f9f899a6fa0d"), new Guid("f14bb479-6e36-47e9-af6e-0e8081c0be59"), null },
                    { new Guid("8250ced8-e34f-4969-9308-6a7a1731239e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("0436ce5c-847d-4f52-b899-23de0c0ffcad"), new Guid("f14bb479-6e36-47e9-af6e-0e8081c0be59"), null },
                    { new Guid("917247aa-af9a-46d6-b103-074d9a45d62f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("9b9a403a-fe51-43e1-966f-67c4e982beeb"), new Guid("f14bb479-6e36-47e9-af6e-0e8081c0be59"), null },
                    { new Guid("b0fed1b3-9734-4ec4-a3c2-4858c8413105"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("49b54056-ca0d-409f-a1d0-b28ca19ff6bc"), new Guid("f14bb479-6e36-47e9-af6e-0e8081c0be59"), null },
                    { new Guid("c0c8f085-42de-4036-b60e-a06cc7534962"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("7e8dbc94-c9f0-42d6-af32-25543090d534"), new Guid("f14bb479-6e36-47e9-af6e-0e8081c0be59"), null },
                    { new Guid("c78a96a9-05b1-4b27-ab49-2a5532f39fde"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("0e5f04f8-1ae2-4e19-bf8f-ddfeceb2cdd4"), new Guid("f14bb479-6e36-47e9-af6e-0e8081c0be59"), null }
                });

            migrationBuilder.InsertData(
                table: "token_user_role_function",
                columns: new[] { "Id", "CreationTime", "IsDeleted", "RoleId", "UserInfoId" },
                values: new object[] { new Guid("59845bb1-34fb-4ba9-917b-dccb8e8b59f7"), new DateTime(2022, 6, 7, 3, 6, 19, 15, DateTimeKind.Local).AddTicks(1666), false, new Guid("f14bb479-6e36-47e9-af6e-0e8081c0be59"), new Guid("db9555b3-c844-492a-9192-8649361cb75e") });

            migrationBuilder.InsertData(
                table: "token_user_department_function",
                columns: new[] { "Id", "CreationTime", "DepartmentId", "IsDeleted", "UserInfoId" },
                values: new object[] { new Guid("7da2a1c5-edc1-4bbe-9721-ce9f7284659e"), new DateTime(2022, 6, 7, 3, 6, 19, 15, DateTimeKind.Local).AddTicks(1666), new Guid("bcf1021f-ed6e-4ac6-834b-84937dd741af"), false, new Guid("db9555b3-c844-492a-9192-8649361cb75e") });

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
