public record Step(int Number, string Instructions);

public record Ingredient(string Name, string Quantity);

public record Recipe(int Id,string Name, IEnumerable<Ingredient> Ingredients, IEnumerable<Step> Steps);

public static class DB
{
    public static IEnumerable<Recipe> Recipes { get; set; } = new List<Recipe>
    {
       new Recipe(1,"Tiramisu",
           new List<Ingredient>
           {
               new Ingredient("Savoiardi Ladyfingers", "300g"),
               new Ingredient("Mascarpone Cheese", "500g"),
               new Ingredient("Eggs", "4"),
               new Ingredient("Sugar", "100g"),
               new Ingredient("Coffee", "300ml"),
               new Ingredient("Rum or Marsala", "2 tablespoons"),
               new Ingredient("Unsweetened cocoa powder", ""),
           },
           new List<Step>
           {
               new Step(1,"First of all, make the coffee. For a quick and delicious Italian coffee, we used an Espresso Machine. Then add 2 tablespoons of Rum or Marsala wine."),
               new Step(2,"Separate the egg whites from the yolks. Set aside the yolks and whip the egg whites until stiff: you will get at it when the the egg whites will not move if you turn the bowl over.\r\n\r\nRemember that to whip egg whites to stiff peaks, there should be no trace of yolk. Once ready, set aside."),
               new Step(3,"Now, in a bowl, beat the egg yolks with sugar until light and smooth, 3 to 5 minutes."),
               new Step(4,"In the meantime, pour the mascarpone cheese into a bowl and work it with a spoon to make it softer. Mascarpone cheese must be of excellent quality, creamy and thick. When the yolks are ready add the mascarpone cheese."),
               new Step(5,"Using the flexible-edge k-beater, slowly whip the mascarpone cream for 2 to 3 minutes. Now add the stiffly beaten egg whites."),
               new Step(6,"Mix with a wooden spoon, from bottom up. Mix slowly until smooth and creamy."),
               new Step(7,"Now let’s prepare the layers of ladyfingers and mascarpone cream. You can make 2 or more layers, depending on the width and depth of your pan.\r\n\r\nDip the ladyfingers quickly (1 or 2 seconds) into the coffee. Then arrange the ladyfingers in the casserole of your liking.\r\n\r\nIMPORTANT. The ladyfingers should not soak too much coffee, otherwise the tiramisu will be too rich in coffee and runny."),
               new Step(8," Arrange them so that they cover the bottom of the casserole. Then spread the mascarpone cream over the ladyfingers."),
               new Step(9,"Add another layer of ladyfingers and then top with more mascarpone cream. If you are making the last layer, spread the mascarpone cream generously."),
               new Step(10,"Finally, sprinkle with cocoa powder. You can even add dark chocolate chips, if you like.\r\n\r\nAllow to rest 3 hours in the refrigerator before serving. Even better if you prepare the tiramisu the day before, letting it rest overnight.")
           }),
        new Recipe(2,"Strawberry Cheesecake",
           new List<Ingredient>
           {
               new Ingredient("Digestive biscuits","250g"),
               new Ingredient("Melted butter","100g"),
               new Ingredient("Vanilla pod","1"),
               new Ingredient("Full fat soft cheese","600g"),
               new Ingredient("Icing sugar","100g"),
               new Ingredient("Pot of double cream","284ml"),
               new Ingredient("Strawberries","400g"),
               new Ingredient("Icing dugar","25g"),
           },
           new List<Step>
           {
               new Step(1,"To make the base, butter and line a 23cm loose-bottomed tin with baking parchment. Put the digestive biscuits in a plastic food bag and crush to crumbs using a rolling pin. Transfer the crumbs to a bowl, then pour over the melted butter. Mix thoroughly until the crumbs are completely coated. Tip them into the prepared tin and press firmly down into the base to create an even layer. Chill in the fridge for 1 hr to set firmly."),
               new Step(2,"Slice the vanilla pod in half lengthways, leaving the tip intact, so that the two halves are still joined. Holding onto the tip of the pod, scrape out the seeds using the back of a kitchen knife."),
               new Step(3,"Pour the double cream into a bowl and whisk with an electric mixer until it’s just starting to thicken to soft peaks. Place the soft cheese, icing sugar and the vanilla seeds in a separate bowl, then beat for 2 mins with an electric mixer until smooth and starting to thicken, it will get thin and then start to thicken again. Tip in the double cream and fold it into the soft cheese mix. You’re looking for it to be thickened enough to hold its shape when you tip a spoon of it upside down. If it’s not thick enough, continue to whisk. Spoon onto the biscuit base, starting from the edges and working inwards, making sure that there are no air bubbles. Smooth the top of the cheesecake down with the back of a dessert spoon or spatula. Leave to set in the fridge overnight."),
               new Step(4,"Bring the cheesecake to room temperature about 30 mins before serving. To remove it from the tin, place the base on top of a can, then gradually pull the sides of the tin down. Slip the cake onto a serving plate, removing the lining paper and base. Purée half the strawberries in a blender or food processor with the icing sugar and 1 tsp water, then sieve. Pile the remaining strawberries onto the cake, and pour the purée over the top.")
           }),
        new Recipe(3,"Brownies",
            new List<Ingredient>
            {
                new Ingredient("Eggs","3"),
                new Ingredient("Unsalted butter","185g"),
                new Ingredient("Dark chocolate","185g"),
                new Ingredient("Plain flour","85g"),
                new Ingredient("Cocoa powder","40"),
                new Ingredient("White chocolate","50g"),
                new Ingredient("Milk Chocolate","50g"),
                new Ingredient("Golden caster sugar","275g"),
            },
            new List<Step>
            {
                new Step(1,"Cut 185g unsalted butter into small cubes and tip into a medium bowl. Break 185g dark chocolate into small pieces and drop into the bowl."),
                new Step(2,"Fill a small saucepan about a quarter full with hot water, then sit the bowl on top so it rests on the rim of the pan, not touching the water. Put over a low heat until the butter and chocolate have melted, stirring occasionally to mix them."),
                new Step(3,"Remove the bowl from the pan. Alternatively, cover the bowl loosely with cling film and put in the microwave for 2 minutes on High. Leave the melted mixture to cool to room temperature."),
                new Step(4,"While you wait for the chocolate to cool, position a shelf in the middle of your oven and turn the oven on to 180C/160C fan/gas 4."),
                new Step(5,"Using a shallow 20cm square tin, cut out a square of non-stick baking parchment to line the base. Tip 85g plain flour and 40g cocoa powder into a sieve held over a medium bowl. Tap and shake the sieve so they run through together and you get rid of any lumps."),
                new Step(6,"Chop 50g white chocolate and 50g milk chocolate into chunks on a board."),
                new Step(7,"Break 3 large eggs into a large bowl and tip in 275g golden caster sugar. With an electric mixer on maximum speed, whisk the eggs and sugar. They will look thick and creamy, like a milk shake. This can take 3-8 minutes, depending on how powerful your mixer is. You’ll know it’s ready when the mixture becomes really pale and about double its original volume. Another check is to turn off the mixer, lift out the beaters and wiggle them from side to side. If the mixture that runs off the beaters leaves a trail on the surface of the mixture in the bowl for a second or two, you’re there."),
                new Step(8,"Pour the cooled chocolate mixture over the eggy mousse, then gently fold together with a rubber spatula. Plunge the spatula in at one side, take it underneath and bring it up the opposite side and in again at the middle. Continue going under and over in a figure of eight, moving the bowl round after each folding so you can get at it from all sides, until the two mixtures are one and the colour is a mottled dark brown. The idea is to marry them without knocking out the air, so be as gentle and slow as you like."),
                new Step(9,"Hold the sieve over the bowl of eggy chocolate mixture and resift the cocoa and flour mixture, shaking the sieve from side to side, to cover the top evenly."),
                new Step(10,"Gently fold in this powder using the same figure of eight action as before. The mixture will look dry and dusty at first, and a bit unpromising, but if you keep going very gently and patiently, it will end up looking gungy and fudgy. Stop just before you feel you should, as you don’t want to overdo this mixing."),
                new Step(11,"Finally, stir in the white and milk chocolate chunks until they’re dotted throughout."),
                new Step (12,"Pour the mixture into the prepared tin, scraping every bit out of the bowl with the spatula. Gently ease the mixture into the corners of the tin and paddle the spatula from side to side across the top to level it."),
                new Step(13,"Put in the oven and set your timer for 25 mins. When the buzzer goes, open the oven, pull the shelf out a bit and gently shake the tin. If the brownie wobbles in the middle, it’s not quite done, so slide it back in and bake for another 5 minutes until the top has a shiny, papery crust and the sides are just beginning to come away from the tin. Take out of the oven."),
                new Step(14,"Leave the whole thing in the tin until completely cold, then, if you’re using the brownie tin, lift up the protruding rim slightly and slide the uncut brownie out on its base. If you’re using a normal tin, lift out the brownie with the foil. Cut into quarters, then cut each quarter into four squares and finally into triangles."),
                new Step(15,"They’ll keep in an airtight container for a good two weeks and in the freezer for up to a month.")
            }),
         new Recipe(4,"Tiramisu",
           new List<Ingredient>
           {
               new Ingredient("Savoiardi Ladyfingers", "300g"),
               new Ingredient("Mascarpone Cheese", "500g"),
               new Ingredient("Eggs", "4"),
               new Ingredient("Sugar", "100g"),
               new Ingredient("Coffee", "300ml"),
               new Ingredient("Rum or Marsala", "2 tablespoons"),
               new Ingredient("Unsweetened cocoa powder", ""),
           },
           new List<Step>
           {
               new Step(1,"First of all, make the coffee. For a quick and delicious Italian coffee, we used an Espresso Machine. Then add 2 tablespoons of Rum or Marsala wine."),
               new Step(2,"Separate the egg whites from the yolks. Set aside the yolks and whip the egg whites until stiff: you will get at it when the the egg whites will not move if you turn the bowl over.\r\n\r\nRemember that to whip egg whites to stiff peaks, there should be no trace of yolk. Once ready, set aside."),
               new Step(3,"Now, in a bowl, beat the egg yolks with sugar until light and smooth, 3 to 5 minutes."),
               new Step(4,"In the meantime, pour the mascarpone cheese into a bowl and work it with a spoon to make it softer. Mascarpone cheese must be of excellent quality, creamy and thick. When the yolks are ready add the mascarpone cheese."),
               new Step(5,"Using the flexible-edge k-beater, slowly whip the mascarpone cream for 2 to 3 minutes. Now add the stiffly beaten egg whites."),
               new Step(6,"Mix with a wooden spoon, from bottom up. Mix slowly until smooth and creamy."),
               new Step(7,"Now let’s prepare the layers of ladyfingers and mascarpone cream. You can make 2 or more layers, depending on the width and depth of your pan.\r\n\r\nDip the ladyfingers quickly (1 or 2 seconds) into the coffee. Then arrange the ladyfingers in the casserole of your liking.\r\n\r\nIMPORTANT. The ladyfingers should not soak too much coffee, otherwise the tiramisu will be too rich in coffee and runny."),
               new Step(8," Arrange them so that they cover the bottom of the casserole. Then spread the mascarpone cream over the ladyfingers."),
               new Step(9,"Add another layer of ladyfingers and then top with more mascarpone cream. If you are making the last layer, spread the mascarpone cream generously."),
               new Step(10,"Finally, sprinkle with cocoa powder. You can even add dark chocolate chips, if you like.\r\n\r\nAllow to rest 3 hours in the refrigerator before serving. Even better if you prepare the tiramisu the day before, letting it rest overnight.")
           }),
        new Recipe(5,"Strawberry Cheesecake",
           new List<Ingredient>
           {
               new Ingredient("Digestive biscuits","250g"),
               new Ingredient("Melted butter","100g"),
               new Ingredient("Vanilla pod","1"),
               new Ingredient("Full fat soft cheese","600g"),
               new Ingredient("Icing sugar","100g"),
               new Ingredient("Pot of double cream","284ml"),
               new Ingredient("Strawberries","400g"),
               new Ingredient("Icing dugar","25g"),
           },
           new List<Step>
           {
               new Step(1,"To make the base, butter and line a 23cm loose-bottomed tin with baking parchment. Put the digestive biscuits in a plastic food bag and crush to crumbs using a rolling pin. Transfer the crumbs to a bowl, then pour over the melted butter. Mix thoroughly until the crumbs are completely coated. Tip them into the prepared tin and press firmly down into the base to create an even layer. Chill in the fridge for 1 hr to set firmly."),
               new Step(2,"Slice the vanilla pod in half lengthways, leaving the tip intact, so that the two halves are still joined. Holding onto the tip of the pod, scrape out the seeds using the back of a kitchen knife."),
               new Step(3,"Pour the double cream into a bowl and whisk with an electric mixer until it’s just starting to thicken to soft peaks. Place the soft cheese, icing sugar and the vanilla seeds in a separate bowl, then beat for 2 mins with an electric mixer until smooth and starting to thicken, it will get thin and then start to thicken again. Tip in the double cream and fold it into the soft cheese mix. You’re looking for it to be thickened enough to hold its shape when you tip a spoon of it upside down. If it’s not thick enough, continue to whisk. Spoon onto the biscuit base, starting from the edges and working inwards, making sure that there are no air bubbles. Smooth the top of the cheesecake down with the back of a dessert spoon or spatula. Leave to set in the fridge overnight."),
               new Step(4,"Bring the cheesecake to room temperature about 30 mins before serving. To remove it from the tin, place the base on top of a can, then gradually pull the sides of the tin down. Slip the cake onto a serving plate, removing the lining paper and base. Purée half the strawberries in a blender or food processor with the icing sugar and 1 tsp water, then sieve. Pile the remaining strawberries onto the cake, and pour the purée over the top.")
           }),
        new Recipe(6,"Brownies",
            new List<Ingredient>
            {
                new Ingredient("Eggs","3"),
                new Ingredient("Unsalted butter","185g"),
                new Ingredient("Dark chocolate","185g"),
                new Ingredient("Plain flour","85g"),
                new Ingredient("Cocoa powder","40"),
                new Ingredient("White chocolate","50g"),
                new Ingredient("Milk Chocolate","50g"),
                new Ingredient("Golden caster sugar","275g"),
            },
            new List<Step>
            {
                new Step(1,"Cut 185g unsalted butter into small cubes and tip into a medium bowl. Break 185g dark chocolate into small pieces and drop into the bowl."),
                new Step(2,"Fill a small saucepan about a quarter full with hot water, then sit the bowl on top so it rests on the rim of the pan, not touching the water. Put over a low heat until the butter and chocolate have melted, stirring occasionally to mix them."),
                new Step(3,"Remove the bowl from the pan. Alternatively, cover the bowl loosely with cling film and put in the microwave for 2 minutes on High. Leave the melted mixture to cool to room temperature."),
                new Step(4,"While you wait for the chocolate to cool, position a shelf in the middle of your oven and turn the oven on to 180C/160C fan/gas 4."),
                new Step(5,"Using a shallow 20cm square tin, cut out a square of non-stick baking parchment to line the base. Tip 85g plain flour and 40g cocoa powder into a sieve held over a medium bowl. Tap and shake the sieve so they run through together and you get rid of any lumps."),
                new Step(6,"Chop 50g white chocolate and 50g milk chocolate into chunks on a board."),
                new Step(7,"Break 3 large eggs into a large bowl and tip in 275g golden caster sugar. With an electric mixer on maximum speed, whisk the eggs and sugar. They will look thick and creamy, like a milk shake. This can take 3-8 minutes, depending on how powerful your mixer is. You’ll know it’s ready when the mixture becomes really pale and about double its original volume. Another check is to turn off the mixer, lift out the beaters and wiggle them from side to side. If the mixture that runs off the beaters leaves a trail on the surface of the mixture in the bowl for a second or two, you’re there."),
                new Step(8,"Pour the cooled chocolate mixture over the eggy mousse, then gently fold together with a rubber spatula. Plunge the spatula in at one side, take it underneath and bring it up the opposite side and in again at the middle. Continue going under and over in a figure of eight, moving the bowl round after each folding so you can get at it from all sides, until the two mixtures are one and the colour is a mottled dark brown. The idea is to marry them without knocking out the air, so be as gentle and slow as you like."),
                new Step(9,"Hold the sieve over the bowl of eggy chocolate mixture and resift the cocoa and flour mixture, shaking the sieve from side to side, to cover the top evenly."),
                new Step(10,"Gently fold in this powder using the same figure of eight action as before. The mixture will look dry and dusty at first, and a bit unpromising, but if you keep going very gently and patiently, it will end up looking gungy and fudgy. Stop just before you feel you should, as you don’t want to overdo this mixing."),
                new Step(11,"Finally, stir in the white and milk chocolate chunks until they’re dotted throughout."),
                new Step (12,"Pour the mixture into the prepared tin, scraping every bit out of the bowl with the spatula. Gently ease the mixture into the corners of the tin and paddle the spatula from side to side across the top to level it."),
                new Step(13,"Put in the oven and set your timer for 25 mins. When the buzzer goes, open the oven, pull the shelf out a bit and gently shake the tin. If the brownie wobbles in the middle, it’s not quite done, so slide it back in and bake for another 5 minutes until the top has a shiny, papery crust and the sides are just beginning to come away from the tin. Take out of the oven."),
                new Step(14,"Leave the whole thing in the tin until completely cold, then, if you’re using the brownie tin, lift up the protruding rim slightly and slide the uncut brownie out on its base. If you’re using a normal tin, lift out the brownie with the foil. Cut into quarters, then cut each quarter into four squares and finally into triangles."),
                new Step(15,"They’ll keep in an airtight container for a good two weeks and in the freezer for up to a month.")
            }),
         new Recipe(7,"Tiramisu",
           new List<Ingredient>
           {
               new Ingredient("Savoiardi Ladyfingers", "300g"),
               new Ingredient("Mascarpone Cheese", "500g"),
               new Ingredient("Eggs", "4"),
               new Ingredient("Sugar", "100g"),
               new Ingredient("Coffee", "300ml"),
               new Ingredient("Rum or Marsala", "2 tablespoons"),
               new Ingredient("Unsweetened cocoa powder", ""),
           },
           new List<Step>
           {
               new Step(1,"First of all, make the coffee. For a quick and delicious Italian coffee, we used an Espresso Machine. Then add 2 tablespoons of Rum or Marsala wine."),
               new Step(2,"Separate the egg whites from the yolks. Set aside the yolks and whip the egg whites until stiff: you will get at it when the the egg whites will not move if you turn the bowl over.\r\n\r\nRemember that to whip egg whites to stiff peaks, there should be no trace of yolk. Once ready, set aside."),
               new Step(3,"Now, in a bowl, beat the egg yolks with sugar until light and smooth, 3 to 5 minutes."),
               new Step(4,"In the meantime, pour the mascarpone cheese into a bowl and work it with a spoon to make it softer. Mascarpone cheese must be of excellent quality, creamy and thick. When the yolks are ready add the mascarpone cheese."),
               new Step(5,"Using the flexible-edge k-beater, slowly whip the mascarpone cream for 2 to 3 minutes. Now add the stiffly beaten egg whites."),
               new Step(6,"Mix with a wooden spoon, from bottom up. Mix slowly until smooth and creamy."),
               new Step(7,"Now let’s prepare the layers of ladyfingers and mascarpone cream. You can make 2 or more layers, depending on the width and depth of your pan.\r\n\r\nDip the ladyfingers quickly (1 or 2 seconds) into the coffee. Then arrange the ladyfingers in the casserole of your liking.\r\n\r\nIMPORTANT. The ladyfingers should not soak too much coffee, otherwise the tiramisu will be too rich in coffee and runny."),
               new Step(8," Arrange them so that they cover the bottom of the casserole. Then spread the mascarpone cream over the ladyfingers."),
               new Step(9,"Add another layer of ladyfingers and then top with more mascarpone cream. If you are making the last layer, spread the mascarpone cream generously."),
               new Step(10,"Finally, sprinkle with cocoa powder. You can even add dark chocolate chips, if you like.\r\n\r\nAllow to rest 3 hours in the refrigerator before serving. Even better if you prepare the tiramisu the day before, letting it rest overnight.")
           }),
        new Recipe(8,"Strawberry Cheesecake",
           new List<Ingredient>
           {
               new Ingredient("Digestive biscuits","250g"),
               new Ingredient("Melted butter","100g"),
               new Ingredient("Vanilla pod","1"),
               new Ingredient("Full fat soft cheese","600g"),
               new Ingredient("Icing sugar","100g"),
               new Ingredient("Pot of double cream","284ml"),
               new Ingredient("Strawberries","400g"),
               new Ingredient("Icing dugar","25g"),
           },
           new List<Step>
           {
               new Step(1,"To make the base, butter and line a 23cm loose-bottomed tin with baking parchment. Put the digestive biscuits in a plastic food bag and crush to crumbs using a rolling pin. Transfer the crumbs to a bowl, then pour over the melted butter. Mix thoroughly until the crumbs are completely coated. Tip them into the prepared tin and press firmly down into the base to create an even layer. Chill in the fridge for 1 hr to set firmly."),
               new Step(2,"Slice the vanilla pod in half lengthways, leaving the tip intact, so that the two halves are still joined. Holding onto the tip of the pod, scrape out the seeds using the back of a kitchen knife."),
               new Step(3,"Pour the double cream into a bowl and whisk with an electric mixer until it’s just starting to thicken to soft peaks. Place the soft cheese, icing sugar and the vanilla seeds in a separate bowl, then beat for 2 mins with an electric mixer until smooth and starting to thicken, it will get thin and then start to thicken again. Tip in the double cream and fold it into the soft cheese mix. You’re looking for it to be thickened enough to hold its shape when you tip a spoon of it upside down. If it’s not thick enough, continue to whisk. Spoon onto the biscuit base, starting from the edges and working inwards, making sure that there are no air bubbles. Smooth the top of the cheesecake down with the back of a dessert spoon or spatula. Leave to set in the fridge overnight."),
               new Step(4,"Bring the cheesecake to room temperature about 30 mins before serving. To remove it from the tin, place the base on top of a can, then gradually pull the sides of the tin down. Slip the cake onto a serving plate, removing the lining paper and base. Purée half the strawberries in a blender or food processor with the icing sugar and 1 tsp water, then sieve. Pile the remaining strawberries onto the cake, and pour the purée over the top.")
           }),
        new Recipe(9,"Brownies",
            new List<Ingredient>
            {
                new Ingredient("Eggs","3"),
                new Ingredient("Unsalted butter","185g"),
                new Ingredient("Dark chocolate","185g"),
                new Ingredient("Plain flour","85g"),
                new Ingredient("Cocoa powder","40"),
                new Ingredient("White chocolate","50g"),
                new Ingredient("Milk Chocolate","50g"),
                new Ingredient("Golden caster sugar","275g"),
            },
            new List<Step>
            {
                new Step(1,"Cut 185g unsalted butter into small cubes and tip into a medium bowl. Break 185g dark chocolate into small pieces and drop into the bowl."),
                new Step(2,"Fill a small saucepan about a quarter full with hot water, then sit the bowl on top so it rests on the rim of the pan, not touching the water. Put over a low heat until the butter and chocolate have melted, stirring occasionally to mix them."),
                new Step(3,"Remove the bowl from the pan. Alternatively, cover the bowl loosely with cling film and put in the microwave for 2 minutes on High. Leave the melted mixture to cool to room temperature."),
                new Step(4,"While you wait for the chocolate to cool, position a shelf in the middle of your oven and turn the oven on to 180C/160C fan/gas 4."),
                new Step(5,"Using a shallow 20cm square tin, cut out a square of non-stick baking parchment to line the base. Tip 85g plain flour and 40g cocoa powder into a sieve held over a medium bowl. Tap and shake the sieve so they run through together and you get rid of any lumps."),
                new Step(6,"Chop 50g white chocolate and 50g milk chocolate into chunks on a board."),
                new Step(7,"Break 3 large eggs into a large bowl and tip in 275g golden caster sugar. With an electric mixer on maximum speed, whisk the eggs and sugar. They will look thick and creamy, like a milk shake. This can take 3-8 minutes, depending on how powerful your mixer is. You’ll know it’s ready when the mixture becomes really pale and about double its original volume. Another check is to turn off the mixer, lift out the beaters and wiggle them from side to side. If the mixture that runs off the beaters leaves a trail on the surface of the mixture in the bowl for a second or two, you’re there."),
                new Step(8,"Pour the cooled chocolate mixture over the eggy mousse, then gently fold together with a rubber spatula. Plunge the spatula in at one side, take it underneath and bring it up the opposite side and in again at the middle. Continue going under and over in a figure of eight, moving the bowl round after each folding so you can get at it from all sides, until the two mixtures are one and the colour is a mottled dark brown. The idea is to marry them without knocking out the air, so be as gentle and slow as you like."),
                new Step(9,"Hold the sieve over the bowl of eggy chocolate mixture and resift the cocoa and flour mixture, shaking the sieve from side to side, to cover the top evenly."),
                new Step(10,"Gently fold in this powder using the same figure of eight action as before. The mixture will look dry and dusty at first, and a bit unpromising, but if you keep going very gently and patiently, it will end up looking gungy and fudgy. Stop just before you feel you should, as you don’t want to overdo this mixing."),
                new Step(11,"Finally, stir in the white and milk chocolate chunks until they’re dotted throughout."),
                new Step (12,"Pour the mixture into the prepared tin, scraping every bit out of the bowl with the spatula. Gently ease the mixture into the corners of the tin and paddle the spatula from side to side across the top to level it."),
                new Step(13,"Put in the oven and set your timer for 25 mins. When the buzzer goes, open the oven, pull the shelf out a bit and gently shake the tin. If the brownie wobbles in the middle, it’s not quite done, so slide it back in and bake for another 5 minutes until the top has a shiny, papery crust and the sides are just beginning to come away from the tin. Take out of the oven."),
                new Step(14,"Leave the whole thing in the tin until completely cold, then, if you’re using the brownie tin, lift up the protruding rim slightly and slide the uncut brownie out on its base. If you’re using a normal tin, lift out the brownie with the foil. Cut into quarters, then cut each quarter into four squares and finally into triangles."),
                new Step(15,"They’ll keep in an airtight container for a good two weeks and in the freezer for up to a month.")
            }),
         new Recipe(10,"Tiramisu",
           new List<Ingredient>
           {
               new Ingredient("Savoiardi Ladyfingers", "300g"),
               new Ingredient("Mascarpone Cheese", "500g"),
               new Ingredient("Eggs", "4"),
               new Ingredient("Sugar", "100g"),
               new Ingredient("Coffee", "300ml"),
               new Ingredient("Rum or Marsala", "2 tablespoons"),
               new Ingredient("Unsweetened cocoa powder", ""),
           },
           new List<Step>
           {
               new Step(1,"First of all, make the coffee. For a quick and delicious Italian coffee, we used an Espresso Machine. Then add 2 tablespoons of Rum or Marsala wine."),
               new Step(2,"Separate the egg whites from the yolks. Set aside the yolks and whip the egg whites until stiff: you will get at it when the the egg whites will not move if you turn the bowl over.\r\n\r\nRemember that to whip egg whites to stiff peaks, there should be no trace of yolk. Once ready, set aside."),
               new Step(3,"Now, in a bowl, beat the egg yolks with sugar until light and smooth, 3 to 5 minutes."),
               new Step(4,"In the meantime, pour the mascarpone cheese into a bowl and work it with a spoon to make it softer. Mascarpone cheese must be of excellent quality, creamy and thick. When the yolks are ready add the mascarpone cheese."),
               new Step(5,"Using the flexible-edge k-beater, slowly whip the mascarpone cream for 2 to 3 minutes. Now add the stiffly beaten egg whites."),
               new Step(6,"Mix with a wooden spoon, from bottom up. Mix slowly until smooth and creamy."),
               new Step(7,"Now let’s prepare the layers of ladyfingers and mascarpone cream. You can make 2 or more layers, depending on the width and depth of your pan.\r\n\r\nDip the ladyfingers quickly (1 or 2 seconds) into the coffee. Then arrange the ladyfingers in the casserole of your liking.\r\n\r\nIMPORTANT. The ladyfingers should not soak too much coffee, otherwise the tiramisu will be too rich in coffee and runny."),
               new Step(8," Arrange them so that they cover the bottom of the casserole. Then spread the mascarpone cream over the ladyfingers."),
               new Step(9,"Add another layer of ladyfingers and then top with more mascarpone cream. If you are making the last layer, spread the mascarpone cream generously."),
               new Step(10,"Finally, sprinkle with cocoa powder. You can even add dark chocolate chips, if you like.\r\n\r\nAllow to rest 3 hours in the refrigerator before serving. Even better if you prepare the tiramisu the day before, letting it rest overnight.")
           }),
        new Recipe(11,"Strawberry Cheesecake",
           new List<Ingredient>
           {
               new Ingredient("Digestive biscuits","250g"),
               new Ingredient("Melted butter","100g"),
               new Ingredient("Vanilla pod","1"),
               new Ingredient("Full fat soft cheese","600g"),
               new Ingredient("Icing sugar","100g"),
               new Ingredient("Pot of double cream","284ml"),
               new Ingredient("Strawberries","400g"),
               new Ingredient("Icing dugar","25g"),
           },
           new List<Step>
           {
               new Step(1,"To make the base, butter and line a 23cm loose-bottomed tin with baking parchment. Put the digestive biscuits in a plastic food bag and crush to crumbs using a rolling pin. Transfer the crumbs to a bowl, then pour over the melted butter. Mix thoroughly until the crumbs are completely coated. Tip them into the prepared tin and press firmly down into the base to create an even layer. Chill in the fridge for 1 hr to set firmly."),
               new Step(2,"Slice the vanilla pod in half lengthways, leaving the tip intact, so that the two halves are still joined. Holding onto the tip of the pod, scrape out the seeds using the back of a kitchen knife."),
               new Step(3,"Pour the double cream into a bowl and whisk with an electric mixer until it’s just starting to thicken to soft peaks. Place the soft cheese, icing sugar and the vanilla seeds in a separate bowl, then beat for 2 mins with an electric mixer until smooth and starting to thicken, it will get thin and then start to thicken again. Tip in the double cream and fold it into the soft cheese mix. You’re looking for it to be thickened enough to hold its shape when you tip a spoon of it upside down. If it’s not thick enough, continue to whisk. Spoon onto the biscuit base, starting from the edges and working inwards, making sure that there are no air bubbles. Smooth the top of the cheesecake down with the back of a dessert spoon or spatula. Leave to set in the fridge overnight."),
               new Step(4,"Bring the cheesecake to room temperature about 30 mins before serving. To remove it from the tin, place the base on top of a can, then gradually pull the sides of the tin down. Slip the cake onto a serving plate, removing the lining paper and base. Purée half the strawberries in a blender or food processor with the icing sugar and 1 tsp water, then sieve. Pile the remaining strawberries onto the cake, and pour the purée over the top.")
           }),
        new Recipe(12,"Brownies",
            new List<Ingredient>
            {
                new Ingredient("Eggs","3"),
                new Ingredient("Unsalted butter","185g"),
                new Ingredient("Dark chocolate","185g"),
                new Ingredient("Plain flour","85g"),
                new Ingredient("Cocoa powder","40"),
                new Ingredient("White chocolate","50g"),
                new Ingredient("Milk Chocolate","50g"),
                new Ingredient("Golden caster sugar","275g"),
            },
            new List<Step>
            {
                new Step(1,"Cut 185g unsalted butter into small cubes and tip into a medium bowl. Break 185g dark chocolate into small pieces and drop into the bowl."),
                new Step(2,"Fill a small saucepan about a quarter full with hot water, then sit the bowl on top so it rests on the rim of the pan, not touching the water. Put over a low heat until the butter and chocolate have melted, stirring occasionally to mix them."),
                new Step(3,"Remove the bowl from the pan. Alternatively, cover the bowl loosely with cling film and put in the microwave for 2 minutes on High. Leave the melted mixture to cool to room temperature."),
                new Step(4,"While you wait for the chocolate to cool, position a shelf in the middle of your oven and turn the oven on to 180C/160C fan/gas 4."),
                new Step(5,"Using a shallow 20cm square tin, cut out a square of non-stick baking parchment to line the base. Tip 85g plain flour and 40g cocoa powder into a sieve held over a medium bowl. Tap and shake the sieve so they run through together and you get rid of any lumps."),
                new Step(6,"Chop 50g white chocolate and 50g milk chocolate into chunks on a board."),
                new Step(7,"Break 3 large eggs into a large bowl and tip in 275g golden caster sugar. With an electric mixer on maximum speed, whisk the eggs and sugar. They will look thick and creamy, like a milk shake. This can take 3-8 minutes, depending on how powerful your mixer is. You’ll know it’s ready when the mixture becomes really pale and about double its original volume. Another check is to turn off the mixer, lift out the beaters and wiggle them from side to side. If the mixture that runs off the beaters leaves a trail on the surface of the mixture in the bowl for a second or two, you’re there."),
                new Step(8,"Pour the cooled chocolate mixture over the eggy mousse, then gently fold together with a rubber spatula. Plunge the spatula in at one side, take it underneath and bring it up the opposite side and in again at the middle. Continue going under and over in a figure of eight, moving the bowl round after each folding so you can get at it from all sides, until the two mixtures are one and the colour is a mottled dark brown. The idea is to marry them without knocking out the air, so be as gentle and slow as you like."),
                new Step(9,"Hold the sieve over the bowl of eggy chocolate mixture and resift the cocoa and flour mixture, shaking the sieve from side to side, to cover the top evenly."),
                new Step(10,"Gently fold in this powder using the same figure of eight action as before. The mixture will look dry and dusty at first, and a bit unpromising, but if you keep going very gently and patiently, it will end up looking gungy and fudgy. Stop just before you feel you should, as you don’t want to overdo this mixing."),
                new Step(11,"Finally, stir in the white and milk chocolate chunks until they’re dotted throughout."),
                new Step (12,"Pour the mixture into the prepared tin, scraping every bit out of the bowl with the spatula. Gently ease the mixture into the corners of the tin and paddle the spatula from side to side across the top to level it."),
                new Step(13,"Put in the oven and set your timer for 25 mins. When the buzzer goes, open the oven, pull the shelf out a bit and gently shake the tin. If the brownie wobbles in the middle, it’s not quite done, so slide it back in and bake for another 5 minutes until the top has a shiny, papery crust and the sides are just beginning to come away from the tin. Take out of the oven."),
                new Step(14,"Leave the whole thing in the tin until completely cold, then, if you’re using the brownie tin, lift up the protruding rim slightly and slide the uncut brownie out on its base. If you’re using a normal tin, lift out the brownie with the foil. Cut into quarters, then cut each quarter into four squares and finally into triangles."),
                new Step(15,"They’ll keep in an airtight container for a good two weeks and in the freezer for up to a month.")
            })
    };
}