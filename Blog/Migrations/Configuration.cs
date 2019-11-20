namespace Blog.Migrations { 

   
    using System.Data.Entity.Migrations;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    
    using Blog.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Blog.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Blog.Models.ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // ������� ��� ����
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };

            // ��������� ���� � ��
            roleManager.Create(role1);
            roleManager.Create(role2);

            // ������� �������������
            var admin = new ApplicationUser { Email = "somemail@mail.ru", UserName = "admin" };
            string password = "admin";
            var result = userManager.Create(admin, password);

            // ���� �������� ������������ ������ �������
            if (result.Succeeded)
            {
                // ��������� ��� ������������ ����
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
            }


            Category c = new Category("�������");

            Category c2 = new Category("���");
            Category c3 = new Category("��������");
            Category c4 = new Category("������ �����");
       

            context.Articles.Add(new Article { path = "https://ukrmandry.com.ua/images/5395-2.jpg", Title = "��������", Discription = "�������� � ���� ��������� �������� � ³������� ������", Text= "���� ����� �������� �������� �� �� ������������ �� ����� ������� �� ��������� ��볿 � ������ � ���� ��������. ���� ���������� �����, �� ������� ��� ����: ��� ��������� ��������, �� ���� �������� �� ���������� ������� ���� ���� (���. ���� �����), ��������� ��� ������� ���� ����������, ���� �������� �� � ����, �� �� ������� ��������� ���� ���� ���������, � ����� ���� ������, �� � ����� ����������� ����� ����� � ����� �����. ���� ��������� ������ ������ ������ ������ � ����� ����, �������� ���������� ����� �� ������ �����, �� ������ ��������� ���������, ������, �� �������� �� ����� �� ��������� ������. � �������, �� ������� � �� ������ ������ ��, ����, �� ���� ����� ������� �� ���������. �� ������� �������� � ��������. �������������� ������� ������� �������, �� ��������� ����� ����� ����� �� �� 5 ����� �� �. �.. ³� ����� ������� � �����, �� �������� �� ����. � ���� ����� �� ��������, �� ������ ������ � � ����� ���� �������� ��������, ���� �������� �������� �GIM(M)IR�(�ò�̲л). � ��������� ��� (�� � � ����� ����'������� �����) ���� �� ��������� �� ������ ��. ������� ����� � ���� ����� ����� ������� ������. ���� ���������� � ������ ���������� �������� ���������, �����, ��������, � ���� ����� ��������, ����-�������, � ������ � ���� ��������� � ��������.", CN = c });
            base.Seed(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
