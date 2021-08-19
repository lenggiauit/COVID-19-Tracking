import React from 'react'
import './loading.css';
import * as bt from 'react-bootstrap';
const PageLoading: React.FC = () => {
    return (
        <div className="page-loading-logo">
            <div className="logo">
                <bt.Spinner animation="border" variant="info" />
            </div>
        </div>
    )
}
export default PageLoading;