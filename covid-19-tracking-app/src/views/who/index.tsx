import React, { ReactElement } from 'react';
import * as bt from 'react-bootstrap';
import Layout from '../../components/layout';
import { useAppContext } from '../../contexts/appContext';

const Who: React.FC = (): ReactElement => {
    const { locale, setLocale, appSetting } = useAppContext();

    return (
        <Layout>
            <bt.Container>
                <bt.Row>
                    <bt.Col> {appSetting.GetCountries.Method} </bt.Col>
                </bt.Row>
            </bt.Container>
        </Layout>
    )
};

export default Who;