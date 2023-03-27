<template>
    <div class="submit-form">
        <div v-if="!submitted">
            <div class="form-group">
                <label for="employeeName">Employee Name</label>
                <input type="text" class="form-control" id="employeeName" required v-model="permission.employeeName"
                    name="employeeName" />
            </div>
            <div class="form-group">
                <label for="employeeName">Employee Last Name</label>
                <input type="text" class="form-control" id="employeeLastName" required v-model="permission.employeeLastName"
                    name="employeeLastName" />
            </div>

            <div class="form-group">
                <label for="requestDate">Request Date</label>
                <input type="text" class="form-control" id="requestDate" required v-model="permission.requestDate"
                    name="requestDate" />
            </div>

            <div class="form-group">
                <label for="permissionTypeId">Permission Type Id</label>
                <input type="text" class="form-control" id="permissionTypeId" required v-model="permission.permissionTypeId"
                    name="permissionTypeId" />
            </div>
            <button @click="savePermission" class="btn btn-success">Submit</button>
        </div>

        <div v-else>
            <h4>You submitted successfully!</h4>
            <button class="btn btn-success" @click="newPermission">Add</button>
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import PermissionDataService from '@/services/PermissionDataService'
import type IPermission from '@/interfaces/permission.interface'
import type ResponseData from '@/interfaces/response-data.interface'

export default defineComponent({
    name: 'add-permission',
    data() {
        return {
            permission: {
                id: 0,
                employeeName: '',
                employeeLastName: '',
                requestDate: new Date(),
                permissionTypeId: 0
            } as IPermission,
            submitted: false
        }
    },
    methods: {
        savePermission() {
            var data = {
                employeeName: this.permission.employeeName,
                employeeLastName: this.permission.employeeLastName,
                requestDate: this.permission.requestDate,
                permissionTypeId: this.permission.permissionTypeId
            }

            PermissionDataService.create(data)
                .then((response: ResponseData) => {
                    this.permission.id = response.data.id
                    console.log(response.data)
                    this.submitted = true
                })
                .catch((e: Error) => {
                    console.log(e)
                })
        },

        newPermission() {
            this.submitted = false
            this.permission = {} as IPermission
        }
    }
})
</script>

<style>
.submit-form {
    max-width: 300px;
    margin: auto;
}
</style>
