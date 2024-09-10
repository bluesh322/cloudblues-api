import axios from "axios";

const BASE_URL = process.env.REACT_APP_BASE_URL || "http://localhost:5001";

/** Request Helper Class.
 *
 * Static class tying together methods used to get/send to to the API.
 *
 */

class RequestHelper {
    static token;

    static async request(endpoint, data = {}, method = "get") {
        console.debug("API Call:", endpoint, data, method);

        const url = `${BASE_URL}/${endpoint}`;
        const headers = { Authorization: `Bearer ${RequestHelper.token}` };
        const params = method === "get" ? data : {};

        try {
            return (await axios({ url, method, data, params, headers })).data;
        } catch (err) {
            console.error("API Error:", err.response);
            let message = err.response.data.error.message;
            throw Array.isArray(message) ? message : [message];
        }
    }

    static async register(registerData) {
        let res = await this.request(`auth/register`, registerData, "post");
        return res.token;
    }

    static async login(loginData) {
        let res = await this.request(`auth/token`, loginData, "post");
        return res.token;
    }

    static async getCurrentUser(username) {
        let res = await this.request(`users/${username}`);
        return res.user;
    }

    static async getMenus(id) {
        let res = await this.request(`menus?restaurant_id=${id}`);
        return res.menus;
    }

    static async createMenu(menuData, itemData, calendarData) {
        const { restaurant_id, title } = menuData;
        let res = await this.request(`menus/`, { restaurant_id, title }, "post");
        const menu_id = res.menu.id;

        for (let item of itemData) {
            let item_id = item.id
            res = await this.request(`menus/menu_item`, { menu_id, item_id }, "post");
        }

        calendarData.menu_id = menu_id;

        res = await this.request(`calendars/`, calendarData, "post")

        return res;
    }

    static async createItem(itemData) {
        let res = await this.request(`items/`, itemData, "post")
        return res.item;
    }

    static async getItems() {
        let res = await this.request(`items/`);
        return res.items;
    }

    static async getItemsFromMenuId(menu_id) {
        let res = await this.request(`menus/menu_item/${menu_id}`);
        return res.items;
    }

    static async deleteMenu(menu_id) {
        let res = await this.request(`menus/${menu_id}`, {}, "delete")
    }

    static async deleteMenuItems(menu_id) {
        let res = await this.request(`menus/menu_item/${menu_id}`, {}, "delete")
        return res.msg;
    }

    static async payment(body) {
        let res = await this.request(`stripe/payment`, body, "post");
        return res;
    }

}

export default RequestHelper;
