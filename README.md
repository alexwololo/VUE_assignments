# VUE_assignments

{{ textinterpolering }}

<!-- importera vue manuellt -->
<script src="https://unpkg.com/vue@next"></script>

<!-- Vue.createApp, som tar ett objekt som ett argument, till exempel med följande JavaScript-kod -->
Vue.createApp({
-
}).mount('#app')


<!-- JavaScript-variabler kan skapas med let, men i Vue.js så kan man skapa “variabler” i ett objekt som sparas under data-nyckeln: -->

<script>
  Vue.createApp({
    data: function () {
      return { message: 'Hello World!' }
    }
  }).mount('#app')
</script>


************************** directives

**v-bind är ett alternativ till setAttribute**
: är en kortform för v-bind


**class-attributet** med v-bind
Istället för att tillhandahålla en sträng, så kan vi tillhandahålla ett objekt.


**style-attributet** med v-bind
Vi skulle då kunna använda conditional-operatorn (bestående av ?- och :-symbolerna) skriva till så här:

************************** directives

Visa ett element eller inte: **v-if (eller v-show)**
Ibland vill man att ett HTML-element antingen ska dyka upp på sidan eller inte, beroende på om någonting är sant eller falskt. Vue.js har stöd för detta via ett speciellt Vue.js-attribut (ett så kallat direktiv) som heter v-if.

Producera element utifrån en sammansättning **(v-for)**
Ibland vill man skapa lika många HTML-element som det finns värden i en array. Vue.js erbjuder ett speciellt attribut/direktiv som är behjälpligt kring detta: v-for.

Sammanfattning
**v-if (v-show)** kan rendera (visa) element beroende på om något är sant (truthy) eller falskt (falsy)
Kan kompletteras med **v-else och/eller v-else-if**
**v-for** kan rendera lika många element som det finns värden i en array (eller ett objekt)

************************** directives

**v-on** ersätter addEventListener
Vi kan, likt med data, skriva onClick() {} istället för onClick: function() {}.
**@ är en kortform för v-on**

En väldigt användbar sak som metoder (som vår onClick-funktion ovan) kan göra är att ändra våra data-värden, och på detta sätt också ändra HTML-koden som vår mallsyntax producerar. Detta görs via nyckelordet **this**.
