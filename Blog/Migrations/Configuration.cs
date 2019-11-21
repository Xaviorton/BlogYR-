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

            // создаем две роли
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };

            // добавляем роли в бд
            roleManager.Create(role1);
            roleManager.Create(role2);

            // создаем пользователей
            var admin = new ApplicationUser { Email = "somemail@mail.ru", UserName = "admin" };
            string password = "admin";
            var result = userManager.Create(admin, password);

            // если создание пользователя прошло успешно
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
            }


            Category c = new Category("Подорожі");

            Category c2 = new Category("Їжа");
            Category c3 = new Category("Традиції");
            Category c4 = new Category("Народні Танці");
       

            context.Articles.Add(new Article { path = "https://ukrmandry.com.ua/images/5395-2.jpg", Title = "Жмеринка", Discription = "Жмеринка — місто обласного значення у Вінницькій області", Text= "Свою назву Жмеринка отримала від сіл розташованих по обидві сторони від залізничної колії — Велика і Мала Жмеринка. Щодо походження назви, то існують різні версії: одні дослідники вважають, що вона походить від польського вислову «жму руку» (пол. «жме ренке»), сказаному при зустрічі двох переможців, інші вбачають її в тому, що на території сучасного міста було поселення, в якому жили гончарі, які з глини виготовляли різний посуд — «жали ринки». Інші дослідники шукали витоки значно глибше в історії краю, вважаючи походження назви від кореня «жмир», що означає самоназву кіммерійців, племен, які населяли цю землю до скіфського періоду. Є гіпотеза, що «джемері» — це густий темний ліс, хащі, на місці якого виникли ці поселення. Та найбільш ймовірною є наступна. Давньогрецький історик Геродот свідчить, що подільська земля відома світові ще за 5 сторіч до н. е.. Він згадує алозонів і неврів, які заселяли ці землі. З його праць ми дізнаємось, що південь України в ті далекі часи населяли кіммерійці, яких ассирійці називали «GIM(M)IR»(«ГІММІР»). В українській мові (як і в інших слов'янських мовах) звук «ж» чергується із звуком «г». Можливо звідси і пішла назва наших далеких предків. Вона збереглася у назвах подільських поселень Чемеринці, Чемер, Чемериси, в назві трави чемериці, одежі-чемерки, а згодом і назві поселення — Жмеринка.", CN = c });
            base.Seed(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
