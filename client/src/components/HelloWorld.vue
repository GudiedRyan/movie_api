<template>
  <div class="hello">
    <h1>Motion Picture Library</h1>
    <button v-on:click="add">Add</button>
    <table v-if="show_table">
      <tr>
        <th>Name</th>
        <th>Description</th>
        <th>Release Year</th>
        <th>Actions</th>
      </tr>
      <tr v-for="post in posts" :key="post.id">
        <td>{{post["name"]}}</td>
        <td>{{post["description"]}}</td>
        <td>{{post["releaseYear"]}}</td>
        <td>
          <button v-on:click="edit">Edit</button>
          <button>Copy</button>
          <button v-on:click="del(post.id)">Delete</button>
        </td>
      </tr>
    </table>
    <!-- Add form -->
    <form v-if="add_form">
      <label>Name:</label>
      <input v-model="new_name" maxlength="50">
      <br>
      <br>
      <label>Description:</label>
      <input v-model="new_desc" maxlength="500">
      <br>
      <br>
      <label>Release Year</label>
      <input type="quantity" v-model="new_year" min="1890" max="2021">
      <br>
      <br>
      <button v-on:click="post">Submit</button> 
    </form>
    <!-- Edit form -->
    <form v-if="edit_form">
      <label>Name:</label>
      <input v-model="new_name" maxlength="50">
      <br>
      <br>
      <label>Description:</label>
      <input v-model="new_desc" maxlength="500">
      <br>
      <br>
      <label>Release Year</label>
      <input type="quantity" v-model="new_year" min="1890" max="2021">
      <br>
      <br>
      <button v-on:click="put(Id)">Submit</button> 
    </form>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  data() {
    return {
      posts: [],
      errors: [],
      show_table: true,
      add_form: false,
      edit_form: false,
      new_name: null,
      new_desc: null,
      new_year: null

    }
  },

  created() {
    axios.get(`http://localhost:5000/api/movies`)
    .then(response => {
      this.posts = response.data
      console.log(response.data)
    })
    .catch(e => {
      this.errors.push(e)
    })
  },
  methods: {
    del(Id, e) {
      axios.delete(`http://localhost:5000/api/movies/${Id}`)
      .then(response => {
        this.post.splice(Id,1)
        return response
      })
      e.preventDefault();
    },
    add() {
      this.show_table = false;
      this.add_form = true;
    },
    post(e) {
      axios.post(`http://localhost:5000/api/movies`, {name: this.new_name, description: this.new_desc, releaseYear: Number(this.new_year)})
      .then(response => {
        this.show_table = true
        this.add_form = false
        this.new_name = null
        this.new_desc = null
        this.new_year = null
        return response
      })
      e.preventDefault();
      
    },
    edit() {
      this.show_table = false;
      this.edit_form = true;
    },
    put(Id, e) {
      axios.put(`http://localhost:5000/api/movies/${Id}`, {name: this.new_name, description: this.new_desc, releaseYear: Number(this.new_year)})
      .then(response => {
        this.show_table = true
        this.edit_form = false
        this.new_name = null
        this.new_desc = null
        this.new_year = null
        return response
      })
      e.preventDefault();
    }
    }
  }

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
table, th, td {
  border: 2px, solid black;
}
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
