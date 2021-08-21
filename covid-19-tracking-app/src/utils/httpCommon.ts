import axios from "axios";
import { AppSetting } from "../type";
let appSetting: AppSetting = require('../appSetting.json');

export default axios.create(
    {
        baseURL: appSetting.BaseUrl,
        headers: {
            "Content-type": "application/json"
        }
    });