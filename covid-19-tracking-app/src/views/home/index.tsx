import React, { ReactElement } from 'react';
import * as bt from 'react-bootstrap';
import Layout from '../../components/layout';
import { useAppContext } from '../../contexts/appContext';

const Home: React.FC = (): ReactElement => {
    const { locale, setLocale, appSetting } = useAppContext();

    var axios = require('axios');
    var data = '';

    var config = {
        method: 'get',
        url: 'https://covid19-update-api.herokuapp.com/api/v1',
        headers: {
            'Content-Type': 'application/json',
            'Access-Control-Allow-Origin': '*'
        },
        data: data
    };

    axios(config)
        .then(function (response: any) {
            console.log(JSON.stringify(response.data));
        })
        .catch(function (error: any) {
            console.log(error);
        });



    return (
        <Layout>
            <bt.Container>
                <bt.Row>
                    <bt.Col> {appSetting.GetCountries.Url} </bt.Col>
                </bt.Row>
            </bt.Container>
        </Layout>
    )
};

export default Home;