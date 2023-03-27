<template>
  <div class="list row">
    <div class="col-md-6">
      <h4>Permissions List</h4>
      <ul class="list-group">
        <li
          class="list-group-item"
          :class="{ active: index == currentIndex }"
          v-for="(permission, index) in permissions"
          :key="index"
          @click="setActivePermission(permission, index)"
        >
        {{ permission.employeeName }} {{ permission.employeeLastName }}
        </li>
      </ul>
    </div>
    <div class="col-md-6">
      <div v-if="currentPermission">
        <h4>permission</h4>
        <div>
          <label><strong>Employee Name:</strong></label> {{ currentPermission.employeeName}}
        </div>
        <div>
          <label><strong>Employee Last Name:</strong></label> {{ currentPermission.employeeLastName}}
          <label><strong>Request Date:</strong></label> {{ currentPermission.requestDate }}
        </div>
         <div>
          <label><strong>Employee Last Name:</strong></label> {{ currentPermission.employeeLastName}}
          <label><strong>Permission Type:</strong></label> {{ currentPermission.permissionTypeId }}
        </div>
        <router-link :to="'/permissions/' + currentPermission.id" class="badge badge-warning"
          >Edit</router-link
        >
      </div>
      <div v-else>
        <br />
        <p>Please click on a permission...</p>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import PermissionDataService from '@/services/PermissionDataService'
import type IPermission from '@/interfaces/permission.interface'
import type ResponseData from "@/interfaces/response-data.interface";

export default defineComponent({
  name: 'permissions-list',
  data() {
    return {
      permissions: [] as IPermission[],
      currentPermission: {} as IPermission,
      currentIndex: -1,
      title: ''
    }
  },
  methods: {
    retrievePermissions() {
      PermissionDataService.getAll()
        .then((response: ResponseData) => {
          this.permissions = response.data
          console.log(response.data)
        })
        .catch((e: Error) => {
          console.log(e)
        })
    },

    refreshList() {
      this.retrievePermissions()
      this.currentPermission = {} as IPermission
      this.currentIndex = -1
    },

    setActivePermission(permission: IPermission, index: number) {
      this.currentPermission= permission;
      this.currentIndex = permission ? index : -1;
    },
  },
  mounted() {
    this.retrievePermissions()
  }
})
</script>

<style>
.list {
  text-align: left;
  max-width: 750px;
  margin: auto;
}
</style>
