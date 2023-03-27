<template>
  <div v-if="currentPermission" class="edit-form">
    <h4>permission</h4>
    <form>
      <div class="form-group">
        <label for="employeeName">Employee Name</label>
        <input
          type="text"
          class="form-control"
          id="employeeName"
          v-model="currentPermission.employeeName"
        />
      </div>
      <div class="form-group">
        <label for="employeeLastName">Employee Last Name</label>
        <input
          type="text"
          class="form-control"
          id="employeeLastName"
          v-model="currentPermission.employeeLastName"
        />
      </div>
      <div class="form-group">
        <label for="requestDate">Request Date</label>
        <input type="text" class="form-control" id="requestDate" v-model="currentPermission.requestDate" />
      </div>
      <div class="form-group">
        <label for="permissionTypeId">Permission Type Id</label>
        <input
          type="text"
          class="form-control"
          id="permissionTypeId"
          v-model="currentPermission.permissionTypeId"
        />
      </div>
    </form>

    <button class="badge badge-danger mr-2" @click="deletePermission">Delete</button>

    <button type="submit" class="badge badge-success" @click="updatePermission">Update</button>
    <p>{{ message }}</p>
  </div>

  <div v-else>
    <br />
    <p>Please click on a permission...</p>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import PermissionDataService from '@/services/PermissionDataService'
import type ResponseData from '@/interfaces/response-data.interface'
import type IPermission from '@/interfaces/permission.interface'

export default defineComponent({
  name: 'permission',
  data() {
    return {
      currentPermission: {} as IPermission,
      message: ''
    }
  },
  methods: {
    getPermission(id: any) {
      PermissionDataService.get(id)
        .then((response: ResponseData) => {
          this.currentPermission = response.data
          console.log(response.data)
        })
        .catch((e: Error) => {
          console.log(e)
        })
    },

    updatePermission() {
      PermissionDataService.update(this.currentPermission.id, this.currentPermission)
        .then((response: ResponseData) => {
          console.log(response.data)
          this.message = 'The permission was updated successfully!'
        })
        .catch((e: Error) => {
          console.log(e)
        })
    },

    deletePermission() {
      PermissionDataService.delete(this.currentPermission.id)
        .then((response: ResponseData) => {
          console.log(response.data)
          this.$router.push({ name: 'permissions' })
        })
        .catch((e: Error) => {
          console.log(e)
        })
    }
  },
  mounted() {
    this.message = ''
    this.getPermission(this.$route.params.id)
  }
})
</script>

<style>
.edit-form {
  max-width: 300px;
  margin: auto;
}
</style>
