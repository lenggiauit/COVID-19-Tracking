import React, { ReactElement } from 'react';
import * as bt from 'react-bootstrap';
import Layout from '../../components/layout';
import { useAppContext } from '../../contexts/appContext';

const VaccineData: React.FC = (): ReactElement => {
    const { locale, setLocale, appSetting } = useAppContext();

    return (
        <Layout>
            <bt.Container>
                <bt.Row>
                    <bt.Col></bt.Col>
                </bt.Row>
            </bt.Container>
        </Layout>
    )
};

export default VaccineData;