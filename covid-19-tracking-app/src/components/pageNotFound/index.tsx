import React, { ReactElement } from 'react';
import * as bt from 'react-bootstrap';
import Navigation from '../../components/navigation/'
import { AppProvider } from '../../contexts/appContext';
import EnvironmentInfo from '../environmentInfo';
import { Translation } from '../translation';


const PageNotFound: React.FC = (): ReactElement => {
    return (
        <>
            <div className="px-4 py-5 my-5 text-center">
                <h1 className="mt-5"><Translation tid="page_not_found" /></h1>
            </div>

        </>
    )
};

export default PageNotFound;

