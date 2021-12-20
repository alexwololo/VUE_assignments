Vue.createApp({
  data() {
    return {
      arr: [{ name: "Joe" }, { name: "Jane" }, { name: "Mary" }],
      obj: {
        title: "Vue Book",
        author: "John Smith",
        publishedYear: 2021,
      },
    };
  },
}).mount("#app");
