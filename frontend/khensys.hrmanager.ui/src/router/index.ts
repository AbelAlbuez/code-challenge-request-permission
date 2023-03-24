import { createRouter, createWebHistory } from 'vue-router'

const routes = [
    {
      path: "/",
      alias: "/permission",
      name: "permission",
      component: () => import("./components/permission/PermissionList")
    },
    {
      path: "/permission/:id",
      name: "permission-details",
      component: () => import("./components/permission/Permission")
    },
    {
      path: "/add",
      name: "add",
      component: () => import("./components/permission/AddPermission")
    }
  ];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;