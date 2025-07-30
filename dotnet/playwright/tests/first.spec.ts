import { test, expect, BrowserContext } from '@playwright/test';
import { link } from 'fs';
import path from 'path';

const authFile = path.join(__dirname, '../playwright/.auth/user.json');
test('testhome', async ({ browser }) => {
    
const fs = require('fs');
const storageState = JSON.parse(fs.readFileSync(authFile, 'utf8'));
const context: BrowserContext = await browser.newContext({ storageState });
const page = await context.newPage();

//await page.context().storageState({ path: authFile });

    await page.goto('https://ogt-gtm-web-qa.8443.aws-int.thomsonreuters.com/gtm/home');
    page.waitForLoadState("domcontentloaded");
    await page.getByRole('button', { name: 'Anurag Ruhela ' }).click();
    await page.getByText('Version:25.1').click();
    await page.locator('body').press('Escape');
    await page.getByRole('button', { name: 'Reg FTA (2032) ' }).click();
    await page.getByPlaceholder('Search by name or partner id').press('Escape');
  });