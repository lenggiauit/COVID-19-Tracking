import React from 'react';
import * as bt from 'react-bootstrap';
import { Translation } from '../translation';
import { AppSetting } from '../../type';

let appSetting: AppSetting = require('../../appSetting.json');


const EnvironmentInfo: React.FC = () => {
    if (process.env.NODE_ENV.toLocaleUpperCase() == 'DEVELOPMENT' && !appSetting.ForceHideEnvironment) {
        return (
            < bt.Alert variant='info' >
                <small><Translation tid="app_environment_message" params={[process.env.NODE_ENV.toLocaleUpperCase()]} /></small>
            </bt.Alert >
        );
    }
    else {
        return (<></>);
    }
}

export default EnvironmentInfo;




